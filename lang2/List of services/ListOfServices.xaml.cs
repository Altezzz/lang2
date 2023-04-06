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
using System.Drawing;
using System.IO;
namespace lang2.List_of_services
{

    /// <summary>
    /// Логика взаимодействия для ListOfServices.xaml
    /// </summary>
    /// 
    public partial class ListOfServices : Window
    {
        public ListOfServices()
        {
            InitializeComponent();

            LV.ItemsSource = AppConnect.modelOdb.Service.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow employee = new MainWindow();
            employee.Show();
            this.Close();
        }

        private void btnSearchExcursion_Click(object sender, RoutedEventArgs e)
        {
            ListOfServices employee = new ListOfServices();
            employee.Show();
            this.Close();
        }

        private void searchExcursionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (searchExcursionTextBox.Text != "")
            {
                LV.ItemsSource = AppConnect.modelOdb.Service.Where(x => x.Title.ToLower().Contains(searchExcursionTextBox.Text.ToLower())).ToList();
            }
            else
            {
                LV.ItemsSource = AppConnect.modelOdb.Service.ToList();
            }
        }

        private void LV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
