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
    /// Логика взаимодействия для PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Window
    {
        public PageAdmin()
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

        private void btnSearchExcursion_Click(object sender, RoutedEventArgs e)
        {
           PageAdmin employee = new PageAdmin();
            employee.Show();
            this.Close();
        }

        private void buttR_Click(object sender, RoutedEventArgs e)
        {
            updateProduct();
        }
        private void updateProduct()
        {
            if (LV.SelectedItem as Service == null)
            {
                var result = MessageBox.Show("Выберете услугу", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                if (result == MessageBoxResult.OK)
                {
                    return;
                }
            }
            EditServices addExhibitWindow = new EditServices(LV.SelectedItem as Service);

            addExhibitWindow.ShowDialog();
        }
        private void buttRem_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удолить данные", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var removeServ = LV.SelectedItem as Service;
                AppConnect.modelOdb.Service.Remove(removeServ);
                AppConnect.modelOdb.SaveChanges();
                LV.ItemsSource = AppConnect.modelOdb.Service.ToList();
                MessageBox.Show("Данные удалены");
            }
        }
       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddAService employee = new AddAService();
            employee.Show();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Recordings employee = new Recordings();
            employee.Show();
        }

        private void LV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnUpdateCopy_Click(object sender, RoutedEventArgs e)
        {
            Print employee = new Print();
            employee.Show();
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnst_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnkl_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}