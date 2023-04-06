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
    /// Логика взаимодействия для EditServices.xaml
    /// </summary>
    public partial class EditServices : Window
    {
        public Service service;
        public EditServices(Service t)
        {
            InitializeComponent();
            service = t;
            nameExhibitTextBox.Text = service.Title;
            nameExhibitTextBox_Copy.SelectionStart = (int)service.Cost;
            nameExhibitTextBox_Copy1.CaretIndex = service.DurationInSeconds;
            nameExhibitTextBox_Copy2.Text = service.Description;
        }   

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
 
            this.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            service.Title = nameExhibitTextBox.Text;
            service.Cost = nameExhibitTextBox_Copy.SelectionStart;
            service.DurationInSeconds = nameExhibitTextBox_Copy1.CaretIndex;
            service.Description = nameExhibitTextBox_Copy2.Text;
            AppConnect.modelOdb.SaveChanges();
            MessageBox.Show("Днные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

    }
}
