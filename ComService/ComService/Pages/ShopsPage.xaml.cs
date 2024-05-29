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
    /// Логика взаимодействия для ShopsPage.xaml
    /// </summary>
    public partial class ShopsPage : Page
    {
        List<Shops> ListServ = new List<Shops>();
        public ShopsPage()
        {
            InitializeComponent();
            DGShop.ItemsSource = AppData.Context.Shops.ToList();
        }
        private void Update()
        {
            ListServ = AppData.Context.Shops.ToList();

            DGShop.ItemsSource = ListServ;
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AddShopsPage());
            Update();
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.Context.Shops.Remove((Shops)DGShop.SelectedItem);
            AppData.Context.SaveChanges();
            Update();
        }

        private void RedBtn_Click(object sender, RoutedEventArgs e)
        {            
            AppData.MainFrame.Navigate(new AddShopsPage(DGShop.SelectedItem as Shops));
            Update();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void DGShop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = DGShop.SelectedItem != null;
            DelBtn.IsEnabled = value;
            RedBtn.IsEnabled = value;
        }
    }
}
