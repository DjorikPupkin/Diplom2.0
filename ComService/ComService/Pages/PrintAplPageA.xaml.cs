using System;
using mshtml;
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
    /// Логика взаимодействия для PrintAplPageA.xaml
    /// </summary>
    public partial class PrintAplPageA : Page
    {
        public PrintAplPageA()
        {
            InitializeComponent();
            var ListOfApl = AppData.Context.ApplicationUs.ToList();
            var result = new StringBuilder();

            result.Append("<html>");
            result.Append("<meta charset='utf-8'/b> </p>");
            result.Append("<body>");
            result.Append("<p align='center'><b>Отчет по заявкам</b> </p>");
            result.Append("<table width=100% border=1 border color=#000 stele='border-collapse:collapse;'>");
            result.Append("<tr>");
            result.Append("<td align=center><b>Дата заявки</b></td>");
            result.Append("<td align=center><b>Номер компьютера</b></td>");
            result.Append("<td align=center><b>Описание заявки</b></td>");
            result.Append("<td align=center><b>Статус</b></td>");
            result.Append("<td align=center><b>Работник</b></td>");
            result.Append("<td align=center><b>Деталь</b></td>");
            result.Append("<td align=center><b>Дата передачи заявки</b></td>");
            result.Append("<td align=center><b>Дата выполнения</b></td>");
            result.Append("</tr>");
            foreach (var Item in ListOfApl)
            {
                result.Append("<tr>");
                result.Append($"<td align=center>{Item.ApplicationDateTime}</td>");
                result.Append($"<td align=center>{Item.Comid}</td>");
                result.Append($"<td align=center>{Item.Description}</td>");
                result.Append($"<td align=center>{Item.Status.Status1}</td>");
                if (Item.User.UserName != null)                   
                    result.Append($"<td align=center>{Item.User.UserName}</td>");
                else
                    result.Append($"<td align=center></td>");
                if(Item.Detail.DetailName != null)
                    result.Append($"<td align=center>{Item.Detail.DetailName}</td>");
                else
                    result.Append($"<td align=center></td>");
                if(Item.DateTimeWorker != null)
                    result.Append($"<td align=center>{Item.DateTimeWorker}</td>");
                else
                    result.Append($"<td align=center></td>");
                result.Append($"<td align=center>{Item.DoneAplDateTime}</td>");
                result.Append("</tr>");
            }
            result.Append("</table>");
            result.Append("</body>");
            result.Append("</html>");
            WbP.NavigateToString(result.ToString());

        }

        private void PrBtn_Click(object sender, RoutedEventArgs e)
        {
            var document = WbP.Document as IHTMLDocument2;
            document.execCommand("Print");
        }
    }
}
