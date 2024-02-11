using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestForKids.Model;
using TestForKids.ViewModel;

namespace TestForKids.View
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Page
    {
        private SharedViewModel _sharedViewModel;

        public AddUser(SharedViewModel sharedViewModel)
        {
            InitializeComponent();
            _sharedViewModel = sharedViewModel;

        }


        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get data from textboxes
                string firstName = txtFname.Text;
                string lastName = txtLname.Text;
                string email = txtEmail.Text;
                string password = txtPassword.Text;

                // Validate that required fields are not empty
                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                    string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; // Stop further execution
                }

                if (!email.Contains("@") && !email.Contains("."))
                {
                    MessageBox.Show("Please fill a correct email, with @ or . in it", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;

                }

                if (password.Length < 5)
                {
                    MessageBox.Show("Please have a password contaning at least 5 letters.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;

                }



                ComboBoxItem selectedGenderItem = (ComboBoxItem)GenderComboBox.SelectedItem;
                string selectedGender = selectedGenderItem.Content.ToString();

                // Create a new user
                User newUser = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    State = "",
                    Country = "",
                    Email = email,
                    Password = password,
                    Gender = selectedGender,
                };

                _sharedViewModel.UsersList.Add(newUser);
                MessageBox.Show("User added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoginSound.Play();
                LoginSound.Stop();
                LoginSound.Position = TimeSpan.Zero;
                LoginSound.Play();
                // Optionally, clear the textboxes after adding the user
                ClearTextBoxes();

                // Navigate to the login page
                Login login = new Login(_sharedViewModel);
                NavigationService.Navigate(login);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ClearTextBoxes()
        {
            // Clear the content of all textboxes
            txtFname.Clear();
            txtLname.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Login loginPage = new Login(_sharedViewModel);
                NavigationService.Navigate(loginPage);
                // Show the LoginPage

                // Close the current window
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error hh", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
