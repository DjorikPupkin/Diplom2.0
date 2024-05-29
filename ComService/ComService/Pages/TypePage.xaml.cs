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
    /// Логика взаимодействия для TypePage.xaml
    /// </summary>
    public partial class TypePage : Page
    {
        List<DetailType> ListServ = new List<DetailType>();
        public TypePage()
        {
            InitializeComponent();
            DGType.ItemsSource = AppData.Context.DetailType.ToList();
        }
        private void Update()
        {
            ListServ = AppData.Context.DetailType.ToList();

            DGType.ItemsSource = ListServ;
        }
        private void AddBtnT_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AddTypePage());
        }

        private void RedBtnT_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AddTypePage(DGType.SelectedItem as DetailType));
        }

        private void DelBtnT_Click(object sender, RoutedEventArgs e)
        {
            AppData.Context.DetailType.Remove((DetailType)DGType.SelectedItem);
            AppData.Context.SaveChanges();
            Update();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void DGType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = DGType.SelectedItem != null;
            DelBtnT.IsEnabled = value;
            RedBtnT.IsEnabled = value;
        }
    }
}
