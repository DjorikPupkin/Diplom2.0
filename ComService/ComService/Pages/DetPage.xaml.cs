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
    /// Логика взаимодействия для DetPage.xaml
    /// </summary>
    public partial class DetPage : Page
    {
        List<Detail> ListServ = new List<Detail>();
        public DetPage()
        {
            
            InitializeComponent();
            DGCompl.ItemsSource = AppData.Context.Detail.ToList();
        }
        private void Update()
        {
            ListServ = AppData.Context.Detail.ToList();

            DGCompl.ItemsSource = ListServ;
        }
        private void DGCompl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = DGCompl.SelectedItem != null;
            DetBtnDel.IsEnabled = value;
            DetBtnPAdd.IsEnabled = value;
        }
        private void DetBtnP_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AddCompPage());
            Update();
        }

        private void DetBtnPAdd_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AddCompPage(DGCompl.SelectedItem as Detail));
            Update();
        }

        private void TypeBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new TypePage());
            Update();
        }

        private void DetBtnDel_Click(object sender, RoutedEventArgs e)
        {
            AppData.Context.Detail.Remove((Detail)DGCompl.SelectedItem);
            AppData.Context.SaveChanges();
            Update();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }

        
    }
}
