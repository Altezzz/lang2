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
    /// Логика взаимодействия для AddServiseClient.xaml
    /// </summary>
    public partial class AddServiseClient : Window
    {
        public ClientService addt;
        
        public AddServiseClient(Service t)
        {
            InitializeComponent();
            foreach (Client item in AppConnect.modelOdb.Client.ToList())
            {
                combo.Items.Add(item.FirstName);
            }

            list.Text = t.Title;
            list.DataContext = AppConnect.modelOdb.Service.Where(x => x.ID == t.ID).ToList();
        }

      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();   
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                ClientService service = new ClientService()
                {
                    ClientID = AccountHelpClass.id,
                    ServiceID = AccountHelpClass.id,
                    StartTime = Convert.ToDateTime(textBox3_Copy.Text),
                };

                AppConnect.modelOdb.ClientService.Add(service);
                AppConnect.modelOdb.SaveChanges();
                MessageBox.Show("Клиент успешно добавлен!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message.ToString(), "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void qwe_Click(object sender, RoutedEventArgs e)
        {
            string t = textBox3.Text;
            string[] v = t.Split(':');
            DateTime dt = dateTimePicker1.DisplayDate;
            string DT = dt.ToString();
            string[] x = DT.Split(' ');
            string[] d = x[0].Split('.');
            DateTime w = new DateTime(Convert.ToInt32(d[2]), Convert.ToInt32(d[1]), Convert.ToInt32(d[0]), Convert.ToInt32(v[0]), Convert.ToInt32(v[1]), 0);
            //DateTime y = Convert.ToDateTime(x[0]+v[0]+v[1]);
            textBox3_Copy.Text = w.ToString();
        }

        private void combo_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}