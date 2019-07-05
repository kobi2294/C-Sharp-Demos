using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace TplDemo
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

        private void Button_Click_old(object sender, RoutedEventArgs e)
        {
            progressBar.IsIndeterminate = true;
            statusText.Text = "Calculating, please wait...";

            var task = Task.Factory.StartNew(() =>
            {
                var results = PrimesCalculator.GetAllPrimes(1000, 180000);
                return results;

            });

            task.ContinueWith(t =>
            {
                resultsList.ItemsSource = task.Result;

                progressBar.IsIndeterminate = false;
                statusText.Text = "Calculation Completed";
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                progressBar.IsIndeterminate = true;
                statusText.Text = "Calculating, please wait...";

                resultsList.ItemsSource = await Task.Factory.StartNew(() => PrimesCalculator.GetAllPrimes(1000, 180000));
                statusText.Text = "Calculation Completed";
            }
            catch (Exception)
            {
                statusText.Text = "Calculation Failed";
            }
            finally {
                progressBar.IsIndeterminate = false;
            }
        }


    }
}
