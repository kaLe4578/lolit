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
    /// Логика взаимодействия для EditClient.xaml
    /// </summary>
    public partial class EditClient
    {
        Client _client = new Client();

        DemastrazionEntities demastrazionEntities = new DemastrazionEntities();

        public EditClient()
        {
            InitializeComponent();
        }

        public EditClient(Client client)
        {
            InitializeComponent();
            textBoxN.Text = client.N;
            textBoxEmail.Text = client.Email;
            textBoxP.Text = client.P;
            textBoxPhone.Text = client.Phone;
            textBoxS.Text = client.S;
            _client.id = client.id;
            _client.
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (Check())
            {
                try
                {
                    if (_client.id == 0)
                    {
                        _client.N = textBoxN.Text;
                        _client.S = textBoxS.Text;
                        _client.P = textBoxP.Text;
                        _client.Phone = textBoxPhone.Text;
                        _client.Email = textBoxEmail.Text;
                        demastrazionEntities.Client.Add(_client);
                        MessageBox.Show("Клиент добавлен");
                    }
                    else
                    {
                        Client tempClient = demastrazionEntities.Client.FirstOrDefault(cl => cl.id == _client.id);
                        tempClient.Email = textBoxEmail.Text;
                        tempClient.N = textBoxN.Text;
                        tempClient.S = textBoxS.Text;
                        tempClient.P = textBoxP.Text;
                        tempClient.Phone = textBoxPhone.Text;
                        MessageBox.Show("Клиент изменен");
                    }
                    demastrazionEntities.SaveChanges();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }
        private bool Check()
        {
            StringBuilder error = new StringBuilder();
            if (textBoxEmail.Text == "" && textBoxPhone.Text == "")
            {
                error.AppendLine("Введите телефон или Email");
            }
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
