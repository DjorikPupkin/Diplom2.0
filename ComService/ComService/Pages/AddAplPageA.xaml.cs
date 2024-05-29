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
    /// Логика взаимодействия для AddAplPageA.xaml
    /// </summary>
    public partial class AddAplPageA : Page
    {
        List<ApplicationUs> ListServ = new List<ApplicationUs>();
        bool isUpdates = false;

        ApplicationUs curentA = new ApplicationUs();
        public AddAplPageA()
        {
            InitializeComponent();
            ListServ = AppData.Context.ApplicationUs.ToList();
        }
        public AddAplPageA(ApplicationUs selectedAplicationUs)
        {
            InitializeComponent();
            ListServ = AppData.Context.ApplicationUs.ToList();
            curentA = selectedAplicationUs;
            Dtp.Value = curentA.ApplicationDateTime;
            TbComN.Text = curentA.Comid.ToString();
            TbDes.Text = curentA.Description;
            isUpdates = true;
        }

        private void NewAplBtn_Click(object sender, RoutedEventArgs e)
        {
            var err = "";
            if (string.IsNullOrWhiteSpace(Convert.ToString(Dtp.Value))) err += "Выберите дату\n";
            if (string.IsNullOrWhiteSpace(TbComN.Text)) err += "Заполните поле номер компьютера\n";
            if (string.IsNullOrWhiteSpace(TbDes.Text)) err += "Заполните поле описание\n";

            if (err == "")
            {
                if (!isUpdates)
                {
                    AppData.Context.ApplicationUs.Add(new ApplicationUs
                    {
                        ApplicationDateTime = Convert.ToDateTime(Dtp.Value),
                        Description = TbDes.Text,
                        Comid = Convert.ToInt32(TbComN.Text),
                        StatusID = 1,
                    });
                    AppData.Context.SaveChanges();
                    NavigationService.GoBack();
                }
                else
                {
                    curentA.ApplicationDateTime = Convert.ToDateTime(Dtp.Value);
                    curentA.Description = TbDes.Text;
                    curentA.Comid = Convert.ToInt32(TbComN.Text);
                    curentA.StatusID = 1;
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
