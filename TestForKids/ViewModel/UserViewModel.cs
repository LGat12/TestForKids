﻿// UserViewModel.cs

using TestForKids.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TestForKids.ViewModel
{
    class UserViewModel : INotifyPropertyChanged
    {
        private SharedViewModel _sharedViewModel;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshUsers()
        {
            // Don't need to reload data, just notify UI
            OnPropertyChanged(nameof(Users));
        }
        public UserViewModel(SharedViewModel sharedViewModel)
        {
            _sharedViewModel = sharedViewModel;

            if (_sharedViewModel.UsersList == null || _sharedViewModel.UsersList.Count == 0)
            {
                _sharedViewModel.UsersList = new List<User>
                {
                new User { UserId = 1, FirstName = "ליאם", LastName = "גטלן", City = "תל אביב", State = "TA", Country = "ישראל", Email = "l@g.com", Password = "1234", Gender = "Male" },
                new User { UserId = 2, FirstName = "משה", LastName = "לוי", City = "ירושלים", State = "JM", Country = "ישראל", Email = "moshe@example.com", Password = "password2", Gender = "Male" },
                new User { UserId = 3, FirstName = "שרה", LastName = "גולן", City = "חיפה", State = "HA", Country = "ישראל", Email = "sarah@example.com", Password = "password3", Gender = "Female" },
                new User { UserId = 4, FirstName = "יעקב", LastName = "פרץ", City = "באר שבע", State = "BS", Country = "ישראל", Email = "yaakov@example.com", Password = "password4", Gender = "Male" },
                new User { UserId = 5, FirstName = "רחל", LastName = "מאיר", City = "אשדוד", State = "ASD", Country = "ישראל", Email = "rachel@example.com", Password = "password5", Gender = "Female" },
                new User { UserId = 6, FirstName = "דוד", LastName = "גור", City = "נתניה", State = "NT", Country = "ישראל", Email = "david@example.com", Password = "password6", Gender = "Male" },
                new User { UserId = 7, FirstName = "מרים", LastName = "זכאי", City = "עפולה", State = "AF", Country = "ישראל", Email = "miriam@example.com", Password = "password7", Gender = "Female" },
                new User { UserId = 8, FirstName = "עידו", LastName = "אביטל", City = "אילת", State = "IL", Country = "ישראל", Email = "ido@example.com", Password = "password8", Gender = "Male" },
                new User { UserId = 9, FirstName = "תמר", LastName = "פלאי", City = "טבריה", State = "TB", Country = "ישראל", Email = "tamar@example.com", Password = "password9", Gender = "Female" },
                new User { UserId = 10, FirstName = "יפה", LastName = "כהן", City = "קריית שמונה", State = "KS", Country = "ישראל", Email = "yafe@example.com", Password = "password10", Gender = "Male" }

                };

            }
        }

        public List<User> Users
        {
            get { return _sharedViewModel.UsersList; }
        }
    }
}
