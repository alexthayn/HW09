using HW09.Commands;
using HW09.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace HW09.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public MainWindowViewModel() : this(new GetContacts()) { }

        public MainWindowViewModel(IDataService data)
        {
            this.data = data;

            OpenFile = new FileCommand(
            true,
            async () =>
            {
                VCFFilePath = await data.GetVCFFileAsync();
                LoadFile.RaiseCanExecuteChanged();
            });
            OpenFile.RaiseCanExecuteChanged();
        }

        private readonly IDataService data;

        public string Title => "Contacts Viewer";

        public FileCommand OpenFile { get; set; }
        private List<Contact> _contacts;
        public List<Contact> Contacts
        {
            get
            {
                return _contacts;
            }
            set
            {
                _contacts = value;
                OnPropertyChanged(nameof(Contacts));
            }
        }

        private Contact _selectedContact;
        public Contact SelectedContact
        {
            get
            {
                return _selectedContact;
            }
            set
            {
                _selectedContact = value;
                OnPropertyChanged(nameof(SelectedContact));
            }
        }

        private string _vcfFilePath;
        public string VCFFilePath
        {
            get => _vcfFilePath;
            set
            {
                _vcfFilePath = value;
                OnPropertyChanged(nameof(VCFFilePath));
                LoadFile.RaiseCanExecuteChanged();
            }
        }

        private FileCommand _loadFile;
        public FileCommand LoadFile => _loadFile ?? (_loadFile = new FileCommand(
            /*data.FileExists(VCFFilePath)*/true,
            async () =>
            {
                Contacts = data.GetContactsFromFile(VCFFilePath);
            }
            ));


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
