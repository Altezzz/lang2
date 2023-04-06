using lang2.Admin;
using lang2.ApplicationData;
using lang2.List_of_services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static lang2.ApplicationData.Admin;

namespace lang2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var userObj = AppConnect.modelOdb.Admin.FirstOrDefault(x => x.Login == loginTextBox.Text.Length && x.Password == passwordTextBox.Password.Length);
                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    AccountHelpClass.id = userObj.ID;
                    switch (userObj.ID)
                    {
                        case 1:
                            PageAdmin employee = new PageAdmin();
                            employee.Show();
                            this.Close();
                            break;
                        case 2:
                        default:
                            MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка " + Ex.Message.ToString() + "Критическая работа приложения!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void loginButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            ListOfServices employee = new ListOfServices();
            employee.Show();
            this.Close();
        }
    }
}
