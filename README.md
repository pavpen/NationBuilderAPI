NationBuilderAPI
================

A .NET binding to NationBuilder's Web API.


Sample Usage
------------

* Compile and reference the \<NationBuilderAPI.dll\> in your project.

* You need to obtain an access token for your NationBuilder app in order to be able to call NationBuilder's API methods (endpoints).  You can obtain one by completing an OAuth login and token exchange.  Once you have the access token you can use it like this:

# Code:


```C#
using NationBuilderAPI.V1;

NationBuilderSession nbSession = new NationBuilderSession("your-nation-slug", "your-access-token");

// Get a page of the top 100 people in our nation:
PeopleIndexResponse resp = nbSession.GetPeople(1, 100);

foreach (AbbreviatedPerson p in resp.results)
{
  // Use the person data.  E.g., display the name and e-mail:
  outpTextBox.AppendText("E-mail: " + p.email + ", Name: " + p.first_name + " " + p.last_name + "\n");
}
```

License
-------

This project is distribute under GPL v.2.

--
Pav
