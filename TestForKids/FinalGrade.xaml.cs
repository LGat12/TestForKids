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
using System.Windows.Shapes;

namespace TestForKids
{
    /// <summary>
    /// Interaction logic for FinalGrade.xaml
    /// </summary>
    public partial class FinalGrade : Window
    {
        public FinalGrade(int SumGrade, string name, int WrongForPlus, int WrongForMinus)
        {
            InitializeComponent();
            int finalGrade = SumGrade;
            Final_Grade.Text = $"{finalGrade}";
            
            GradeAvaluation(finalGrade, name, WrongForPlus, WrongForMinus);

            

        }


        
        public void GradeAvaluation(int finalGrade, string name, int WrongForPlus, int WrongForMinus)
        {
            try 
            {

                if (WrongForMinus >= 1 && WrongForPlus >= 1)
                {
                    Notes.Text = $"*You were wrong {WrongForPlus} time/s on your addition answers \n " +
                        $"and {WrongForMinus} time/s on your subtraction";
                }

                else if (WrongForPlus >= 1)
                {
                    Notes.Text = $"*Note to yourself, {WrongForPlus} of your addition answers were wrong";
                }

                else if (WrongForMinus >= 1)
                {
                    Notes.Text = $"*Note to yourself, {WrongForMinus} of your subtraction answers were wrong";
                }


            } 
            
            catch (Exception ex) 
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            try
            {
                if (finalGrade == 100)
                {
                    Perfect.Play();
                    Last_Words.Text = $"Perfect score! Good job {name}!";
                    Perfect_image.Visibility = Visibility.Visible;
                }
                else if (finalGrade >= 80 && finalGrade < 100)
                {
                    Excelent.Play();
                    Last_Words.Text = $"Nice test {name}!";
                }
                else if (finalGrade > 55 && finalGrade < 80)
                {
                    Nice.Play();
                    Last_Words.Text = $"Nice Try Keep working {name}!";
                }
                else
                {
                    Fail.Play();
                    Last_Words.Text = ":(";
                    angryEmojiImage.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        }
    }

