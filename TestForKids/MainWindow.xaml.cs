using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

namespace TestForKids
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
      
         

        }

        private void Submit_Name_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = "";


        }
        private void Submit_Name_KeyDown(object sender, KeyEventArgs e) // פונקציה שתגרום למקש אנטר לעבוד על הכפתור המשך
        {
            if (e.Key == Key.Enter)
            {
                המשך_Click(sender, e);

                e.Handled = true;
            }
        }
        private void המשך_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Submit_Name != null && Submit_Name.Text != null && Submit_Name.Text.Length > 0)
                {

                    string enteredName = char.ToUpper(Submit_Name.Text[0]) + Submit_Name.Text.Substring(1);

                    if (!string.IsNullOrEmpty(enteredName) & !string.IsNullOrWhiteSpace(enteredName) & enteredName != "שם" & !enteredName.All(char.IsDigit))
                    {
                        EnterGame game = new EnterGame(enteredName);
                        game.Show();
                        this.Close();
                    }
                    else
                    {
                        
                        Error.Play();
                        Error.Stop();
                        Error.Position = TimeSpan.Zero;
                        Error.Play();
                        MessageBox.Show("Please enter a valid name.");

                    }
                }
               
            }
            catch (Exception ex)
            {
                Error.Play();

                MessageBox.Show($"An error occurred: {ex.Message}\n\nInner Exception: {ex.InnerException?.Message}");
            }
        }


        private void Submit_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }
    }
}
