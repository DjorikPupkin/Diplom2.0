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
    /// Логика взаимодействия для AddPurPage.xaml
    /// </summary>
    public partial class AddPurPage : Page
    {
        Purchase curentP = new Purchase();
        private Storage _storage;
        public AddPurPage()
        {
            InitializeComponent();
            
            CbDetail.ItemsSource = AppData.Context.Detail.ToList();
            CbShop.ItemsSource = AppData.Context.Shops.ToList();
        }
       

        private void TbQua_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var det = AppData.Context.Detail.ToList().Where(u => u.DetailName == CbDetail.Text).FirstOrDefault();
            int idd = det.id;
            var sho = AppData.Context.Shops.ToList().Where(u => u.ShopName == CbShop.Text).FirstOrDefault();
            int ids = sho.id;
            _storage = AppData.Context.Storage.Where(z => z.DetailId == idd).FirstOrDefault();
            var err = "";
            if (CbShop.SelectedItem == null) err += "Выберите магазин\n";
            if (CbDetail.SelectedItem == null) err += "Выберите деталь\n";
            if (!int.TryParse(TbQua.Text, out int amount)) err += "Проверьте правильность заполнения количества";

            if (err == "")
            {
                AppData.Context.Purchase.Add(new Purchase()
                {
                    Quantity = amount,
                    DetailId =idd,
                    PurchaseDateTime = Convert.ToDateTime(DtpD.Value),                   
                    ShopId = ids,
                });
                var lastAmount = AppData.Context.Storage.ToList().Where(x => x.Detail == CbDetail.SelectedItem)?.LastOrDefault()?.Quantity ?? 0;

                if (_storage != null)
                {
                    _storage.Quantity = lastAmount + amount;
                }
                else
                {
                    AppData.Context.Storage.Add(new Storage()
                    {
                        DetailId = idd,
                        Quantity = lastAmount + amount,
                    });
                }
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
