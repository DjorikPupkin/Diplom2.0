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
    /// Логика взаимодействия для AddAplPageW.xaml
    /// </summary>
    public partial class AddAplPageW : Page
    {
        List<ApplicationUs> ListServ = new List<ApplicationUs>();
        bool isUpdates = false;
        ApplicationUs curentA = new ApplicationUs();
        List<Detail> ListCBD = new List<Detail>();
        public AddAplPageW()
        {
            InitializeComponent();
            ListServ = AppData.Context.ApplicationUs.ToList();
            ListCBD = AppData.Context.Detail.ToList();
            CbDetail.ItemsSource = ListCBD;
            
        }
        public AddAplPageW(ApplicationUs selectedAplicationUs)
        {
            InitializeComponent();
            curentA = selectedAplicationUs;
            ListServ = AppData.Context.ApplicationUs.ToList();
           
            ListCBD = AppData.Context.Detail.ToList();
            CbDetail.ItemsSource = ListCBD;
          
            isUpdates = true;
        }
        private void SaveAplBtn_Click(object sender, RoutedEventArgs e)
        {
            var ListD = AppData.Context.Detail.ToList().Where(p => p.DetailName == CbDetail.Text).FirstOrDefault();
            int detid = ListD.id;
            var ListS = AppData.Context.Storage.ToList().Where(p => p.DetailId == detid).FirstOrDefault();
            var err = "";
            var de = AppData.Context.Detail.ToList().Where(u => u.DetailName == CbDetail.Text).FirstOrDefault();
            int id = de.id;
            if (string.IsNullOrWhiteSpace(Convert.ToString(DtpD.Value))) err += "Выберите дату\n";
            if (string.IsNullOrWhiteSpace(CbDetail.Text)) err += "Выберите комплектющие\n";
            if (err == "")
            {
                ListS.Quantity -= 1;
                curentA.DoneAplDateTime = Convert.ToDateTime(DtpD.Value);
                    curentA.Detailid = id;
                    curentA.StatusID = 3;                
                    AppData.Context.SaveChanges();
                    NavigationService.GoBack();
                
            }
            else
            {
                MessageBox.Show(err);
            }
        }

    }
}
