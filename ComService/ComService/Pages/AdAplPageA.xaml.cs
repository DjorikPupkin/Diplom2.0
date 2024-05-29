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
    /// Логика взаимодействия для AdAplPageA.xaml
    /// </summary>
    public partial class AdAplPageA : Page
    {
        
       List<ApplicationUs> ListServ = new List<ApplicationUs>();
        List<User> ListU = new List<User>();
        bool isUpdates = false;
        ApplicationUs curentA = new ApplicationUs();
        User curentU = new User();
        List<Detail> ListCBD = new List<Detail>();
        List<ApplicationUs> ListWR = new List<ApplicationUs>();
        List<User> ListW = new List<User>();

       
        public AdAplPageA(ApplicationUs selectedAplicationUs )
        { 
            InitializeComponent();
            var wuser = AppData.Context.User.ToList().Where(p => p.Roleid == 3);
            ListW = wuser.ToList();
            isUpdates = true;
            CbWorker.ItemsSource = ListW;
            ListServ = AppData.Context.ApplicationUs.ToList();
            ListU = AppData.Context.User.ToList();
            curentA = selectedAplicationUs;
            DtpD.Value = curentA.DateTimeWorker;
            
            
        }
        private void SaveAplBtn_Click(object sender, RoutedEventArgs e)
        {
            var us = AppData.Context.User.ToList().Where(u => u.UserName == CbWorker.Text).FirstOrDefault();
            int id = us.id;
            var err = "";
            if (string.IsNullOrWhiteSpace(Convert.ToString(DtpD.Value))) err += "Выберите дату\n";
            if (string.IsNullOrWhiteSpace(CbWorker.Text)) err += "Выберите работника\n";

            if (err == "")
            {
                if (!isUpdates)
                {
                    AppData.Context.ApplicationUs.Add(new ApplicationUs
                    {
                        DateTimeWorker = Convert.ToDateTime(DtpD.Value),
                        StatusID = 4,
                        Worid = id
                    });
                    AppData.Context.SaveChanges();
                    NavigationService.GoBack();
                }
                else
                {
                    curentA.DateTimeWorker = Convert.ToDateTime(DtpD.Value);
                    curentA.Worid = id;
                    curentA.StatusID = 4;
                    AppData.Context.SaveChanges();
                    NavigationService.GoBack();                                                 
                }
            }
            else 
            {
                MessageBox.Show(err);
            }
        }
    }
}
