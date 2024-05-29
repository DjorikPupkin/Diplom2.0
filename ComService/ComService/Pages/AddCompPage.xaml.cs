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
    /// Логика взаимодействия для AddCompPage.xaml
    /// </summary>
    public partial class AddCompPage : Page
    {
        bool isUpdates = false;
        List<DetailType> ListCBD = new List<DetailType>();
        Detail curentD = new Detail();
        public AddCompPage()
        {
            InitializeComponent();
            ListCBD = AppData.Context.DetailType.ToList();
            CbDetailType.ItemsSource = ListCBD;
            
        }
        public AddCompPage(Detail selectedDetail)
        {
            InitializeComponent();
            ListCBD = AppData.Context.DetailType.ToList();
            CbDetailType.ItemsSource = ListCBD;
            curentD = selectedDetail;
            TbDN.Text = curentD.DetailName;
            TbDD.Text = curentD.Description;
           
            isUpdates = true;
        }

        private void NewDetailBtn_Click(object sender, RoutedEventArgs e)
        {
           

            var ListDT = AppData.Context.DetailType.ToList().Where(p => p.NameType == CbDetailType.Text).FirstOrDefault();
            int typeid = ListDT.id;
           
            var err = "";
            if (CbDetailType.SelectedItem == null) err += "Выберите Комплект\n";
            if (string.IsNullOrWhiteSpace(TbDN.Text)) err += "Укажите название\n";
            if (string.IsNullOrWhiteSpace(TbDD.Text)) err += "Укажите описание\n";
            if (err == "")
            {
                if (!isUpdates)
                {
                    AppData.Context.Detail.Add(new Detail
                    {
                        DetailName = TbDN.Text,
                        Description = TbDD.Text,
                        DTypeID = typeid
                    });
                    AppData.Context.SaveChanges();
                    NavigationService.GoBack();
                }
                else
                {
                    curentD.Description = TbDD.Text;
                    curentD.DetailName = TbDN.Text;
                    curentD.DTypeID = typeid;
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
