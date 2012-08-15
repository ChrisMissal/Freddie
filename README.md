Freddie
=======

Freddie (the MailChimp mascot) is a .NET API for MailChimp that keeps things simple.

How to use Freddie?
-------------------

First (because chimps can be found in trees) you must create a tree. This can be done one of two ways:

    var tree = new Tree("your-api-key-from-mailchimp.com");
    var response = tree.Do(x => x.Help.GetAccountDetails());

Or, you can add your api key in your configuration and call the static `Create` method of Tree:

    var tree = Tree.Create();
    var response = tree.Do(x => x.Help.GetAccountDetails());

And in your config file:

    <appSettings>
        <add key="Freddie.ApiKey" value="your-api-key-from-mailchimp.com" />
    </appSettings>

Currently, there is little support for all api methods, but since this project was created less than 18 hours ago, I'll be adding more soon.
