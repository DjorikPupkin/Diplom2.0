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
    /// Логика взаимодействия для AddWorPage.xaml
    /// </summary>
    public partial class AddWorPage : Page
    {
        bool isUpdates = false;
        public User _aplu;
        User curentW = new User();
        public AddWorPage()
        {
            InitializeComponent();
            
        }
        public AddWorPage( User selectedUsers)
        {
            InitializeComponent();
            curentW = selectedUsers;
            TbWN.Text = curentW.UserName;
            TbWL.Text = curentW.Login;
            TbWP.Text = curentW.Password;
            isUpdates = true;
        }

        private void NewWork_Click(object sender, RoutedEventArgs e)
        {
            var err = "";
           
            if (string.IsNullOrWhiteSpace(TbWN.Text)) err += "Заполните поле Имя работника\n";
            if (string.IsNullOrWhiteSpace(TbWL.Text)) err += "Заполните поле Логин работника\n";
            if (string.IsNullOrWhiteSpace(TbWP.Text)) err += "Заполните поле Пароль работника\n";
            if (err == "")
            {
                if (!isUpdates)
                {

                    AppData.Context.User.Add(new User
                    {
                        UserName = TbWN.Text,
                        Login = TbWL.Text,
                        Password = TbWP.Text,
                        Roleid = 3,
                    });
                    
                    AppData.Context.SaveChanges();
                    NavigationService.GoBack();
                }
                else
                {
                    curentW.UserName = TbWN.Text;
                    curentW.Login = TbWL.Text;
                    curentW.Password = TbWP.Text;
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
