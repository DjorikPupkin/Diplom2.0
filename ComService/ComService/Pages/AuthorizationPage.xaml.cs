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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
            
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PbPass.Password.Length > 0)
            {
                WM.Visibility = Visibility.Hidden;
            }
            else
            {
                WM.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (TbLog.Text != "" && PbPass.Password != "")
            {

               



                var currentUser = AppData.Context.User.ToList().Where(p => p.Login == TbLog.Text).FirstOrDefault();
                if (currentUser != null)
                {
                    if (currentUser.Password == PbPass.Password)
                    {
                        if (currentUser.Roleid == 1)
                        {
                            AppData.MainFrame.Navigate(new AplPageAllA());
                        }
                        if (currentUser.Roleid == 3)
                        {
                            var user = AppData.Context.User.ToList().FirstOrDefault(u => u.Login == TbLog.Text && u.Password == PbPass.Password);
                            int usid = user.id;
                            CurUs.UsId = usid;
                            if (TbLog.Text != "" && PbPass.Password != "")
                                AppData.MainFrame.Navigate(new DetPage());
                        }    
                        if(currentUser.Roleid == 2)
                        {
                        AppData.MainFrame.Navigate(new AplPage());

                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль!");
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }

       
    }
}
