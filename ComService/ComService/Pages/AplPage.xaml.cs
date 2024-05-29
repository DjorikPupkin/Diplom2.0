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
    /// Логика взаимодействия для AplPage.xaml
    /// </summary>
    public partial class AplPage : Page
    {
        List<ApplicationUs> ListServ = new List<ApplicationUs>();
        public AplPage()
        {
            InitializeComponent();
            DGApl.ItemsSource = AppData.Context.ApplicationUs.ToList();
        }
        private void UpdateApl()
        {
            ListServ = AppData.Context.ApplicationUs.ToList();
           
            DGApl.ItemsSource = ListServ;
        }

        private void DGApl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = DGApl.SelectedItem != null;
            RedAplBtn.IsEnabled = value;

        }
        private void RedAplBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AddAplPage(DGApl.SelectedItem as ApplicationUs));
            UpdateApl();
        }

        private void NewAplBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AddAplPage());
            UpdateApl();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateApl();
        }

        
    }
}
