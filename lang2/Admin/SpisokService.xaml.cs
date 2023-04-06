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

namespace lang2.Admin
{
    /// <summary>
    /// Логика взаимодействия для SpisokService.xaml
    /// </summary>
    public partial class SpisokService : Window
    {
        public SpisokService()
        {
            InitializeComponent();
            LV.ItemsSource = AppConnect.modelOdb.Service.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
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

        private void buttAddS_Click(object sender, RoutedEventArgs e)
        {
            AddServiseClient employee = new AddServiseClient((sender as Button).DataContext as Service);
            employee.Show();
        }
    }
}
