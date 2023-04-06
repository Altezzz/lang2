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
    /// Логика взаимодействия для AddAService.xaml
    /// </summary>
    public partial class AddAService : Window
    {
        public AddAService()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Service serv = new Service()
                {
                    Title = nameExhibitTextBox.Text,
                    Cost = nameExhibitTextBox_Copy.SelectionStart,
                    DurationInSeconds = nameExhibitTextBox_Copy1.CaretIndex,
                    Description = nameExhibitTextBox_Copy2.Text,

                };
                AppConnect.modelOdb.Service.Add(serv);
                AppConnect.modelOdb.SaveChanges();
                MessageBox.Show("Услуга успешно добавлена!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message.ToString(), "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    
    }
}
