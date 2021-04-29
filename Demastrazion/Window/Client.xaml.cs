using Demastrazion.Model;
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

namespace Demastrazion
{
    /// <summary>
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Client 
    {
        DemastrazionEntities demastrazionEntities = new DemastrazionEntities();

        public Client()
        {
            InitializeComponent()
            dataGrid.AutoGenerateColumns = false;
            dataGrid.ItemsSource = demastrazionEntities.Client.ToList();
        }

        private void button_Add_Client_Click(object sender, RoutedEventArgs e)
        {
            EditClient editClientWindow = new EditClient();
            editClientWindow.Show();
        }

        private void button_Delete_Click(object sender, RoutedEventArgs e)
        {
                
        }
    }
}
