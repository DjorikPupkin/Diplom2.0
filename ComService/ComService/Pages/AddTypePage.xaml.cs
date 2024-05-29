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
    /// Логика взаимодействия для AddTypePage.xaml
    /// </summary>
    public partial class AddTypePage : Page
    {
        bool isUpdates = false;        
        DetailType curentT = new DetailType();
        public AddTypePage()
        {
            InitializeComponent();
        }
        public AddTypePage(DetailType selectedDetailType)
        {
            InitializeComponent();
            curentT = selectedDetailType;
            TbTn.Text = curentT.NameType;
            isUpdates = true;
        }

        private void NewType_Click(object sender, RoutedEventArgs e)
        {
            var err = "";        
            if (string.IsNullOrWhiteSpace(TbTn.Text)) err += "Укажите название\n";          
            if (err == "")
            {
                if (!isUpdates)
                {
                    AppData.Context.DetailType.Add(new DetailType
                    {
                        NameType = TbTn.Text
                    });
                    AppData.Context.SaveChanges();
                    NavigationService.GoBack();
                }
                else
                {
                    curentT.NameType = TbTn.Text;                    
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
