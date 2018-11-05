using HW09.Commands;
using HW09.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HW09.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public MainWindowViewModel() : this(new GetContacts(), new GoogleMapService()) { }

        public MainWindowViewModel(IDataService data, IMapService mapService)
        {
            this.data = data;
            this.mapService = mapService;

            OpenFile = new MyCommand(
            true,
            async () =>
            {
                VCFFilePath = await data.GetVCFFileAsync();
                LoadFile.RaiseCanExecuteChanged();
            });

            OpenFile.RaiseCanExecuteChanged();
        }

        private readonly IDataService data;
        private readonly IMapService mapService;
        private string _startLocation;
        public string StartLocation
        {
            get
            {
                return _startLocation;
            }
            set
            {
                _startLocation = value;
                OnPropertyChanged(nameof(StartLocation));
            }
        }

        private string _destination;
        public string Destination
        {
            get
            {
                return _destination;
            }
            set
            {
                _destination = value;
                OnPropertyChanged(nameof(Destination));
            }
        }


        public string Title => "Contacts Viewer";

        public MyCommand OpenFile { get; set; }
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
            }        }

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

        private MyCommand _loadFile;
        public MyCommand LoadFile => _loadFile ?? (_loadFile = new MyCommand(
            /*data.FileExists(VCFFilePath)*/true,
            async () =>
            {
                Contacts = data.GetContactsFromFile(VCFFilePath);
            }
            ));

        private string _textDirections;
        public string TextDirections
        {
            get => _textDirections;
            set
            {
                _textDirections = value;
                OnPropertyChanged(nameof(TextDirections));
            }
        }

        private MyCommand _getDirections;
        public MyCommand GetDirections => _getDirections ?? (_getDirections = new MyCommand(
            true,
            async () =>
            {

                if (StartLocation == null || Destination == null)
                    TextDirections= "Please enter a valid origin/destination";
                else
                    TextDirections = mapService.GetDirections(StartLocation, Destination);
            }
            ));

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
