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
    /// Логика взаимодействия для PrintPurPage.xaml
    /// </summary>
    public partial class PrintPurPage : Page
    {
        public PrintPurPage()
        {
            InitializeComponent();
            var ListOfPur = AppData.Context.Purchase.ToList();
            var result = new StringBuilder();

            result.Append("<html>");
            result.Append("<meta charset='utf-8'/b> </p>");
            result.Append("<body>");
            result.Append("<p align='center'><b>Отчет по закупкам</b> </p>");
            result.Append("<table width=100% border=1 border color=#000 stele='border-collapse:collapse;'>");
            result.Append("<tr>");
            result.Append("<td align=center><b>Дата закупки</b></td>");
            result.Append("<td align=center><b>Комплектующие</b></td>");
            result.Append("<td align=center><b>Магазин</b></td>");
            result.Append("<td align=center><b>Количество</b></td>");           
            result.Append("</tr>");
            foreach (var Item in ListOfPur)
            {
                result.Append("<tr>");
                result.Append($"<td align=center>{Item.PurchaseDateTime}</td>");
                result.Append($"<td align=center>{Item.Detail.DetailName}</td>");
                result.Append($"<td align=center>{Item.Shops.ShopName}</td>");
                result.Append($"<td align=center>{Item.Quantity}</td>");               
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
