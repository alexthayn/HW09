using HW09.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW09.ViewModels
{
    public interface IDataService
    {
        Task<string> GetVCFFileAsync();
        bool FileExists(string path);
        List<Contact> GetContactsFromFile(string filePath);
    }
}