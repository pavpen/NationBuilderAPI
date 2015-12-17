using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationBuilderAPI.V1
{
    public enum ElectionPeriodCode
    {
        Primary = 'P',
        General = 'G',
        Special = 'S',
        Recount = 'E',
        Convention = 'C',
        PreviousCampaign = 'H',
        Other = 'O'
    }

    public enum PaymentType
    {
        Cash = 1,
        CreditCard = 2,
        Check = 3,
        MoneyOrder = 4,
        EFT = 5,
        InKind = 6,
        WireTransfer = 7,
        Other = 8,
        Square = 9,
        ActBlue = 10
    }

    public enum FecType
    {
        Contribution = 'C',
        ExemptLegalExpense = 'E',
        Offsets = 'F',
        DebtOwedToCommittee = 'G',
        Interest = 'I',
        Loan = 'L',
        LoanFromCandidate = 'M',
        Transfer = 'T',
        Other = 'O'
    }

    public static class Enumerations
    {
        public static readonly char[] PaymentTypeCodes = { '!', 'C', 'D', 'K', 'M', 'E', 'I', 'T', 'O', 'D', 'O' };

        public static readonly string[] PaymentTypeNames = {
                                                     "invalid payment type!",
                                                     "Cash",
                                                     "Credit Card",
                                                     "Check",
                                                     "Money Order",
                                                     "EFT",
                                                     "In-Kind",
                                                     "Wire Transfer",
                                                     "Other",
                                                     "Square",
                                                     "ActBlue"
                                                 };
    }
}
