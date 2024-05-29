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

namespace ComService.Pages
{
    /// <summary>
    /// Логика взаимодействия для PurchasePage.xaml
    /// </summary>
    public partial class PurchasePage : Page
    {
        List<Purchase> ListServ = new List<Purchase>();
        public PurchasePage()
        {
            InitializeComponent();
            DGPur.ItemsSource = AppData.Context.Purchase.ToList();
            ListServ = AppData.Context.Purchase.ToList();
        }
        private void Update()
        {
            ListServ = AppData.Context.Purchase.ToList();          
            DGPur.ItemsSource = ListServ;
           
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AddPurPage());
            Update();
        }

        private void RemBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.Context.Purchase.Remove((Purchase)DGPur.SelectedItem);
            AppData.Context.SaveChanges();
            Update();
        }

        private void OtchBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new PrintPurPage());
            Update();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void DGPur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = DGPur.SelectedItem != null;
            RemBtn.IsEnabled = value;
            
        }
    }
}
