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
    /// Логика взаимодействия для AddShopsPage.xaml
    /// </summary>
    public partial class AddShopsPage : Page
    {
        bool isUpdates = false;
        Shops curentS = new Shops();
        public AddShopsPage()
        {
            InitializeComponent();
        }
        public AddShopsPage(Shops selectedShops)
        {
            InitializeComponent();
            curentS = selectedShops;
            TbSn.Text = curentS.ShopName;
            isUpdates = true;
        }

        private void NewShop_Click(object sender, RoutedEventArgs e)
        {
            var err = "";
            if (string.IsNullOrWhiteSpace(TbSn.Text)) err += "Укажите название\n";
            if (err == "")
            {
                if (!isUpdates)
                {
                    AppData.Context.Shops.Add(new Shops
                    {
                        ShopName = TbSn.Text
                    });
                    AppData.Context.SaveChanges();
                    NavigationService.GoBack();
                }
                else
                {
                    curentS.ShopName = TbSn.Text;
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
