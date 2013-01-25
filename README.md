Freddie [![endorse](http://api.coderwall.com/chrismissal/endorsecount.png)](http://coderwall.com/chrismissal)
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

Currently, there is partial support for all api methods. The goal is to add them as they're need in other projects. (Other than the obvious ones of course.

## Usage

The following samples show how to do some basic functions with Freddie.

### Update a list member

This simple example shows how to update a first and last name for a user. There are many other fields you'll want to update, they'll go here as well.

    var member = new {
        id = "your_list_id", // List information can be fetched with Lists => tree.Do(x => x.List.Lists());
        email_address = "your_best_customer@gmail.com",
        merge_vars = new { fname = "Chris", lname = "Missal" }
    };
    var details = tree.Do(x => x.List.ListUpdateMember(member));

    if (details.Success)
    {
        // update was successful
    }
