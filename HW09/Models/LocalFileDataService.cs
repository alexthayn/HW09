using Avalonia.Controls;
using HW09.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using vCardLib;
using vCardLib.Deserializers;
using vCardLib.Collections;


namespace HW09.Models
{
    public class GetContacts : IDataService
    {
        public async Task<string> GetVCFFileAsync()
        {
            var openFileDialog = new OpenFileDialog()
            {
                AllowMultiple = true,
                Title = "Select one or more .vcf files"
            };

            var pathArray = await openFileDialog.ShowAsync();

            if ((pathArray?.Length ?? 0) > 0)
                return pathArray[0];
            return null;
        }

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public List<Contact> GetContactsFromFile(string filePath)
        {
            List<Contact> ListOfContacts = new List<Contact>();

            vCardCollection contacts = Deserializer.FromFile(filePath);

            foreach (vCard contact in contacts)
            {
                ListOfContacts.Add(new Contact()
                {
                    FirstName = contact.GivenName,
                    LastName = contact.FamilyName,
                    MobilePhone = contact.PhoneNumbers.ToString(),
                    Email = contact.EmailAddresses.ToString()
                });                 
            }
            return ListOfContacts;
        }
    }
}
