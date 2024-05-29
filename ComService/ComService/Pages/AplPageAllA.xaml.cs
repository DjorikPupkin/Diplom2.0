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
    /// Логика взаимодействия для AplPageAllA.xaml
    /// </summary>
    public partial class AplPageAllA : Page
    {
        List<ApplicationUs> ListServ = new List<ApplicationUs>();
        public AplPageAllA()
        {
            InitializeComponent();
            DGApl.ItemsSource = AppData.Context.ApplicationUs.ToList();
            ListServ = AppData.Context.ApplicationUs.ToList();
            List<Status> listSearch = AppData.Context.Status.ToList();
            listSearch.Insert(0, new Status
            {
                Status1 = "Все записи"
            });
            CbSer.ItemsSource = listSearch;
            CbSer.SelectedIndex = 0;
        }
        private void DGApl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = DGApl.SelectedItem != null;
            
            RemBtn.IsEnabled = value;
            RedAplBtn.IsEnabled = value;
            NazAplBtn.IsEnabled = value;
        }
       
        private void UpdateApl()
        {
            ListServ = AppData.Context.ApplicationUs.ToList();
            if (CbSer.SelectedIndex == 1)
            {
                int gan = 1;
                ListServ = ListServ.Where(p => p.StatusID.ToString().Contains(gan.ToString())).ToList();
                DGApl.ItemsSource = ListServ;
            }
            if (CbSer.SelectedIndex == 2)
            {
                int gan = 3;
                ListServ = ListServ.Where(p => p.StatusID.ToString().Contains(gan.ToString())).ToList();
                DGApl.ItemsSource = ListServ;
            }
            if (CbSer.SelectedIndex == 0)
            {
                DGApl.ItemsSource = ListServ;
            }
        }
        private void RedAplBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AddAplPageA(DGApl.SelectedItem as ApplicationUs));
            UpdateApl();
        }
        private void RemBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.Context.ApplicationUs.Remove((ApplicationUs)DGApl.SelectedItem);
            AppData.Context.SaveChanges();
            UpdateApl();
        }

        private void CbSer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateApl();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateApl();
        }

        

        private void AddAplBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AddAplPageA());
            UpdateApl();
        }

        private void NazAplBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AdAplPageA(DGApl.SelectedItem as ApplicationUs));
            UpdateApl();
        }
    }
}
