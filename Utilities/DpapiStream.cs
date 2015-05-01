using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Utilities
{
    /// <summary>
    /// A stream wrapper that uses DPAPI to encrypt or decrypt the streamed data.
    /// 
    /// You may be able to use this class on systems where EFS is not supported, or enabled.
    /// </summary>
    public class DpapiStream : Stream
    {
        Stream wrappedStream;
        DataProtectionScope dataProtectionScope;

        public override long Position
        {
            get
            {
                return wrappedStream.Position;
            }
            set
            {
                wrappedStream.Position = value;
            }
        }

        public override long Length
        {
            get { return wrappedStream.Length; }
        }

        public override bool CanRead
        {
            get { return wrappedStream.CanRead; }
        }

        public override bool CanWrite
        {
            get { return wrappedStream.CanWrite; }
        }

        public override bool CanSeek
        {
            get { return wrappedStream.CanSeek; }
        }

        public DpapiStream(Stream streamToWrap, DataProtectionScope dataProtectionScope = DataProtectionScope.CurrentUser)
        {
            this.wrappedStream = streamToWrap;
            this.dataProtectionScope = dataProtectionScope;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (null == buffer)
            {
                throw new ArgumentNullException("buffer");
            }
            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException("offset");
            }
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count");
            }
            if (offset + count > buffer.Length)
            {
                throw new ArgumentException("offset + count > buffer.Length");
            }

            byte[] encryptedBuffer = new byte[count];

            int bytesRead = wrappedStream.Read(encryptedBuffer, 0, encryptedBuffer.Length);

            if (bytesRead < 1)
            {
                return bytesRead;
            }

            if (bytesRead != encryptedBuffer.Length)
            {
                encryptedBuffer = encryptedBuffer.Take(bytesRead).ToArray();
            }

            var decryptedBuffer = ProtectedData.Unprotect(encryptedBuffer, null, dataProtectionScope);

            Array.Copy(decryptedBuffer, 0, buffer, offset, decryptedBuffer.Length);

            return decryptedBuffer.Length;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            var encryptedBuffer = ProtectedData.Protect(buffer.Skip(offset).Take(count).ToArray(), null, dataProtectionScope);

            wrappedStream.Write(encryptedBuffer, 0, encryptedBuffer.Length);
        }

        public override void SetLength(long value)
        {
            wrappedStream.SetLength(value);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return wrappedStream.Seek(offset, origin);
        }

        public override void Flush()
        {
            wrappedStream.Flush();
        }
    }
}
