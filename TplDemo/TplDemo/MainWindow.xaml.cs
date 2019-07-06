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
        private CancellationTokenSource _cts = null;
        private TaskCompletionSource<bool> _tcs = null; 

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
                var results = PrimesCalculator.GetAllPrimes(1000, 180000, CancellationToken.None, null);
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
            _cts = new CancellationTokenSource();

            try
            {
                var confirm = await GetConfirmationFromUser();
                if (!confirm) return;

                progressBar.Value = 0;
                statusText.Text = "Calculating, please wait...";

                var pr = new Progress<double>(val => progressBar.Value = val);

                resultsList.ItemsSource = await Task.Factory.StartNew(() => PrimesCalculator.GetAllPrimes(1000, 180000, _cts.Token, pr));
                statusText.Text = "Calculation Completed";
            }
            catch (OperationCanceledException)
            {
                statusText.Text = "Cancelled";
            }
            catch (Exception)
            {
                statusText.Text = "Calculation Failed";
            }
            finally {
                progressBar.Value = 0;

                _cts = null;
            }
        }

        public Task<bool> GetConfirmationFromUser()
        {
            confirmationPanel.Visibility = Visibility.Visible;
            _tcs = new TaskCompletionSource<bool>();
            return _tcs.Task;
        }

        private void Button_Click_Yes(object sender, RoutedEventArgs e)
        {
            if (_tcs != null)
            {
                _tcs.SetResult(true);
            }
            confirmationPanel.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_No(object sender, RoutedEventArgs e)
        {
            if (_tcs != null)
            {
                _tcs.SetResult(false);
            }
            confirmationPanel.Visibility = Visibility.Collapsed;
        }



        private void Cancel_Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (_cts != null)
            {
                _cts.Cancel();
            }

        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Stopwatch s1 = new Stopwatch();
            s1.Start();
            var t0 = TaskTesting.SayItQuickly();
            var t1 = TaskTesting.SaySomething();
            var t2 = TaskTesting.SaySomethingElse();

            var tall = Task.WhenAny(t0, t1, t2);

            var tfirst = await tall;
            var str = await tfirst;

            s1.Stop();
            Debug.WriteLine(str);
            Debug.WriteLine(s1.Elapsed);
            
        }
    }
}
