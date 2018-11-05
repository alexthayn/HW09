using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using HW09.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW09.Models
{
    //class GoogleDataService : IDataService
    //{
    //    public void auth()
    //    {
    //        string clientId = "alexat789@gmail.com";
    //            //"xxxxxx.apps.googleusercontent.com";
    //        string clientSecret = "8b9a9bf8e@";


    //        string[] scopes = new string[] { "https://www.googleapis.com/auth/contacts.readonly" };     // view your basic profile info.
    //        try
    //        {
    //            // Use the current Google .net client library to get the Oauth2 stuff.
    //            UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = clientId, ClientSecret = clientSecret }
    //                                                                                         , scopes
    //                                                                                         , "test"
    //                                                                                         , CancellationToken.None
    //                                                                                         , new FileDataStore("test")).Result;

    //            // Translate the Oauth permissions to something the old client libray can read
    //            OAuth2Parameters parameters = new OAuth2Parameters();
    //            parameters.AccessToken = credential.Token.AccessToken;
    //            parameters.RefreshToken = credential.Token.RefreshToken;
    //            GetContactsFromGoogle(parameters);
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //        }
    //    }

    //    //public List<Contact> GetContactsFromGoogle(OAuth2Parameters parameters)
    //    //{
    //    //    var GoogleContacts = new List<Contact>();

    //    //    try
    //    //    {
    //    //        RequestSettings settings = new RequestSettings("Google contacts tutorial", parameters);
    //    //        ContactsRequest cr = new ContactsRequest(settings);
    //    //        var f = cr.GetContacts();
    //    //        foreach (Google.Contacts.Contact c in f.Entries)
    //    //        {
    //    //            Contact myContact = new Contact()
    //    //            {
    //    //                FirstName = c.Name.GivenName,
    //    //                LastName = c.Name.FamilyName,
    //    //                Email = c.PrimaryEmail.ToString(),
    //    //                MobilePhone = c.PrimaryPhonenumber.ToString()
    //    //            };
    //    //            GoogleContacts.Add(myContact);
    //    //        }
    //    //    }
    //    //    catch (Exception a)
    //    //    {
    //    //        Console.WriteLine("A Google Apps error occurred.");
    //    //        Console.WriteLine();
    //    //    }
    //    //    return GoogleContacts;
    //    //}

    //    public bool FileExists(string path)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<Contact> GetContactsFromFile(string filePath)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<string> GetVCFFileAsync()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
