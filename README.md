NationBuilderAPI
================

A .NET binding to NationBuilder's Web API.


Sample Usage
------------

```C#
using NationBuilderAPI.V1;

NationBuilderSession nbSession = new NationBuilderSession("your-nation-slug", "your-access-token");

// Get a page of the top 100 people in our nation:
ResultsPageResponse<AbbreviatedPerson> resp = nbSession.GetPeople(1, 100);

foreach (AbbreviatedPerson p in resp.results)
{
  // Use the person data.  E.g., display the name and e-mail:
  outpTextBox.AppendText("E-mail: " + p.email + ", Name: " + p.first_name + " " + p.last_name + "\n");
}
```

* Install the NationBuilderAPI NuGet package in your project. (If, for some reason, you can't install the NuGet package, compile this project, and reference the \<NationBuilderAPI.dll\> in your project.)

* You need to obtain an access token for your NationBuilder app in order to be able to call NationBuilder's API methods (endpoints).  You can obtain one by completing an OAuth login and token exchange.  Once you have the access token you can use it as shown above. (You can also create a 'test token' through Nation Builder's web API.)


### Receive "Person created" Webhooks in a WCF Service:

```C#
// Epose this method in your WCF service, and use its URL to receive "Person created"
// webhook requests:
[WebInvoke(Method = "POST",
    BodyStyle = WebMessageBodyStyle.Bare,
    ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "WebhookReception/NationBuilder/PersonCreated")]
public void NationBuilder_PersonCreated(
    NationBuilderAPI.V1.Webhooks.V4.AutoSerializable.WebhookContent<
      NationBuilderAPI.V1.Webhooks.V4.AutoSerializable.PersonWebhookPayload>
        webhookContent)
{
    NationBuilder_WebhookRequest_CheckAccess(webhookContent);

    // !!!: Process your webhookContent here.
    // Use webhookContent.payload.person.ToPerson() to get the "cannonical"
    // NationBuilderAPI.V1.Person.
}

/// <summary>
/// Validate a webhook's security token.
/// </summary>
/// <param name="webhookContent">The webhook input payload to validate.</param>
/// <returns><c>true</c>, meaning that access was granted, or throws a
///   <see cref="System.ServiceModel.Security.SecurityAccessDeniedException"/>
///   if access was denied.</returns>
private bool NationBuilder_WebhookRequest_CheckAccess<PayloadT>(
    NationBuilderAPI.V1.Webhooks.V4.AutoSerializable.WebhookContent<PayloadT>
      webhookContent)
{
    if (webhookContent.token != "your-webhook-authentication-token")
    {
        throw new System.ServiceModel.Security.SecurityAccessDeniedException(
            "Invalid Nation Builder webhook token!");
    }

    return true;
}
```


License
-------

This project is distributed under GPL v.2.  If you need a different license for a commercial project, send me a note.

--
Pav
