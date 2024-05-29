using ComService.Pages;
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

namespace ComService
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppData.MainFrame = MainFrame;
            AppData.MainFrame.Navigate(new AuthorizationPage());

            
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (AppData.MainFrame.Content is AuthorizationPage)
            {
                
                BtnBack.Visibility = Visibility.Collapsed;
                AplBtn.Visibility = Visibility.Collapsed;
                AplBtnD.Visibility = Visibility.Collapsed;
                PurBtn.Visibility = Visibility.Collapsed;
                StorageBtn.Visibility = Visibility.Collapsed;
                DetBtnP.Visibility = Visibility.Collapsed;
                WorkBtn.Visibility = Visibility.Collapsed;
                ShopBtn.Visibility = Visibility.Collapsed;
                AplBtnW.Visibility = Visibility.Collapsed;
                DetBtnW.Visibility = Visibility.Collapsed;
            }
            else
            {
                BtnBack.Visibility = Visibility.Visible;
               
            }

            if (AppData.MainFrame.Content is DetPage)
            {
               
                AplBtnW.Visibility = Visibility.Visible;
                DetBtnW.Visibility = Visibility.Visible;
            }
            if(AppData.MainFrame.Content is AplPageAllA)
            {
                BtnBack.Visibility = Visibility.Visible;
                AplBtn.Visibility = Visibility.Visible;
                AplBtnD.Visibility = Visibility.Visible;
                PurBtn.Visibility = Visibility.Visible;
                StorageBtn.Visibility = Visibility.Visible;
                DetBtnP.Visibility = Visibility.Visible;
                WorkBtn.Visibility = Visibility.Visible;
                ShopBtn.Visibility = Visibility.Visible;
                AplBtnW.Visibility = Visibility.Collapsed;
                DetBtnW.Visibility = Visibility.Collapsed;
            }
            if(AppData.MainFrame.Content is AplPage)
            {
                AplBtnU.Visibility = Visibility.Visible;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AuthorizationPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        

        private void InFBtn_Click(object sender, RoutedEventArgs e)
        {
            Window editor = new WindowInfo();
            if (editor.ShowDialog() == true)
            {
                
            }
        }

       

        private void AplBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AplPageAllA());
        }

        private void AplBtnD_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AplPageA());
        }

        private void PurBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new PurchasePage());
        }

        private void StorageBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new StoragePage());
        }

        private void DetBtnP_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new DetPage());
        }

        private void WorkBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new WorkerPage());
        }

        private void ShopBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new ShopsPage());
        }

        private void AplBtnW_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AplPageW());
        }

        private void DetBtnW_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new DetPage());
        }

        private void AplBtnU_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AplPage());
        }
    }
}
