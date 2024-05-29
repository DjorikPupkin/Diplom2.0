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
    /// Логика взаимодействия для StoragePage.xaml
    /// </summary>
    public partial class StoragePage : Page
    {
        public StoragePage()
        {
            InitializeComponent();
            DGStorage.ItemsSource = AppData.Context.Storage.ToList();
        }
        private void Update()
        {
            DGStorage.ItemsSource = AppData.Context.Storage.ToList();
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.Context.Storage.Remove((Storage)DGStorage.SelectedItem);
            AppData.Context.SaveChanges();
            Update();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void DGStorage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = DGStorage.SelectedItem != null;
            DelBtn.IsEnabled = value;
            
        }
    }
}
