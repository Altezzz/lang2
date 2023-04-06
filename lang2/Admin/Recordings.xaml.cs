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

namespace lang2.Admin
{
    /// <summary>
    /// Логика взаимодействия для Recordings.xaml
    /// </summary>
    public partial class Recordings : Window
    {

        public Recordings()
        {
            InitializeComponent();
            List.ItemsSource = AppConnect.modelOdb.Service.ToList();
            ComboBox1.SelectedValuePath = "ID";
            ComboBox1.DisplayMemberPath = "Title";
            ComboBox1.ItemsSource = AppConnect.modelOdb.Service.ToList();
            List.ItemsSource = AppConnect.modelOdb.Service.ToList();
            List.ItemsSource = AppConnect.modelOdb.ClientService.ToList();
/*           
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += timer_Tick;
            timer.Start();*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SpisokService serv = new SpisokService();
            serv.Show();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int serv = Convert.ToInt32(ComboBox1.SelectedValue);

            List.ItemsSource = AppConnect.modelOdb.ClientService.Where(x => x.ServiceID == serv).ToList();

        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void pd_click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(List, "Invoice");
                }
            }
            finally
            {
                this.IsEnabled = true;

            }
        }

        private void btnUpdateCopy_Click(object sender, RoutedEventArgs e)
        {
            Print employee = new Print();
            employee.Show();
        }
        /*        void timer_Tick(object sender, EventArgs e)
{
List.ItemsSource = AppConnect.modelOdb.ClientService.ToList();
}*/

    }
}
