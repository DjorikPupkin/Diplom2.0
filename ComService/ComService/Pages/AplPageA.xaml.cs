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
    /// Логика взаимодействия для AplPageA.xaml
    /// </summary>
    public partial class AplPageA : Page
    {
        List<ApplicationUs> ListServ = new List<ApplicationUs>();
        
        public AplPageA()
        {
            InitializeComponent();

            DGApl.ItemsSource = AppData.Context.ApplicationUs.ToList().Where(a => a.StatusID == 3); ;
           
           
        }
       
       
        

      

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new PrintAplPageA());
        }

       
    }
}
