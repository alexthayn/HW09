using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace HW09.Models
{
    public class Contact: IDataErrorInfo, INotifyPropertyChanged
    {
        private string _id;
        private string _firstName;
        private string _lastName;
        string _mobilePhone;
        private string _email;

        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        /// <summary>
        /// Get or set FirstName value
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
                ValidateFirstName();
            }
        }

        /// <summary>
        /// Get or set LastName value
        /// </summary>
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
                ValidateLastName();
            }
        }

        /// <summary>
        /// Get full name value from FirstName and LastName 
        /// </summary>
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        /// <summary>
        /// Get or set MobilePhone value
        /// </summary>
        public string MobilePhone
        {
            get { return _mobilePhone; }
            set
            {
                _mobilePhone = value;
                OnPropertyChanged(nameof(MobilePhone));
            }
        }

        /// <summary>
        /// Get or set Email value
        /// </summary>
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
                ValidateEmail();
            }
        }

        //IDataErrorInfo Implementation
        public Dictionary<string, string> errors = new Dictionary<string, string>();
        public string Error => throw new NotImplementedException();
        public string this[string columnName] => errors.ContainsKey(columnName) ? errors[columnName] : null;

        //Validation methods
        private void ValidateFirstName()
        {
            if (FirstName == null || FirstName.Any(Char.IsWhiteSpace))
                errors[nameof(FirstName)] = "First name must be valid with no extra whitespace.";
            else
                errors[nameof(FirstName)] = null;

            OnPropertyChanged(nameof(FirstName));
        }

        private void ValidateLastName()
        {
            if (LastName == null || LastName.Any(Char.IsWhiteSpace))
                errors[nameof(LastName)] = "Last name must be valid with no extra whitespace.";
            else
                errors[nameof(LastName)] = null;
            OnPropertyChanged(nameof(LastName));
        }

        private void ValidateEmail()
        {
            if (!Email.Contains('@') && !Email.Contains('.'))
                errors[nameof(Email)] = "Please enter a valid email of the form myemail@email.com";
            else
                errors[nameof(Email)] = null;
            OnPropertyChanged(nameof(Email));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
