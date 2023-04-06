using lang2.ApplicationData;
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
using System.Windows.Shapes;
using System.Windows.Threading;
using Excel = Microsoft.Office.Interop.Excel;

namespace lang2.Admin
{
    /// <summary>
    /// Логика взаимодействия для Print.xaml
    /// </summary>
    public partial class Print : Window
    {
        public Print()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ex1_click(object sender, RoutedEventArgs e)
        {
            var spisok = AppConnect.modelOdb.Service.OrderBy(x => x.Title).ToList();
            var aplication = new Excel.Application();
            Excel.Workbook workbook = aplication.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = aplication.Worksheets.Item[1];

            int RowIndex = 2;
            Excel.Range header = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 4]];


            // header.HorizontalAlignment = Excel.HlHAlign.xlHAlignCenter;
            header.Font.Bold = true;
            worksheet.Cells[1][1] = "Название";
            worksheet.Cells[2][1] = "Цена";
            worksheet.Cells[3][1] = "Склад";
            worksheet.Cells[4][1] = "КГ";

            for (int i = 0; i < spisok.Count; i++)
            {
                worksheet.Cells[1][RowIndex] = spisok[i].Title;
                int g = spisok[i].ID;
                Service form0bj = AppConnect.modelOdb.Service.FirstOrDefault(x => x.ID == g);
                if (form0bj != null)
                {
                    worksheet.Cells[2][RowIndex] = form0bj.Cost;
                    worksheet.Cells[3][RowIndex] = form0bj.DurationInSeconds;
                    worksheet.Cells[4][RowIndex] = form0bj.Description;
                }
                RowIndex++;
            }
            aplication.Visible = true;
        }

       

        private void ex2_click(object sender, RoutedEventArgs e)
        {
            var spisok = AppConnect.modelOdb.Client.OrderBy(x => x.FirstName).ToList();
            var aplication = new Excel.Application();
            Excel.Workbook workbook = aplication.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = aplication.Worksheets.Item[1];

            int RowIndex = 2;
            Excel.Range header = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 7]];


            // header.HorizontalAlignment = Excel.HlHAlign.xlHAlignCenter;
            header.Font.Bold = true;
            worksheet.Cells[1][1] = "Фамилия";
            worksheet.Cells[2][1] = "Имя";
            worksheet.Cells[3][1] = "Отчесвто";
            worksheet.Cells[4][1] = "Дата рождения";
            worksheet.Cells[5][1] = "Дата регистрации";
            worksheet.Cells[6][1] = "Email";
            worksheet.Cells[7][1] = "Телефон";

            for (int i = 0; i < spisok.Count; i++)
            {
                worksheet.Cells[1][RowIndex] = spisok[i].FirstName;
                int g = spisok[i].ID;
                Client form0bj = AppConnect.modelOdb.Client.FirstOrDefault(x => x.ID == g);
                if (form0bj != null)
                {
                    worksheet.Cells[2][RowIndex] = form0bj.LastName;
                    worksheet.Cells[3][RowIndex] = form0bj.Patronymic;
                    worksheet.Cells[4][RowIndex] = form0bj.Birthday;
                    worksheet.Cells[5][RowIndex] = form0bj.RegistrationDate;
                    worksheet.Cells[6][RowIndex] = form0bj.Email;
                    worksheet.Cells[7][RowIndex] = form0bj.Phone;
                }
                RowIndex++;
            }
            aplication.Visible = true;
        }
    }
}
