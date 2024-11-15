using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace DeepDiveIntoOOP.Part2WpfApp
{
    /// <summary>
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public string LastName => LastNameTextBox.Text;
        public string FirstName => FirstNameTextBox.Text;
        public string MiddleName => MiddleNameTextBox.Text;
        public string PhoneNumber => PhoneNumberTextBox.Text;
        public string PassportNumber => PassportTextBox.Text;

        public Client NewClient { get; private set; }

        public AddClientWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NewClient = new Client(
           LastNameTextBox.Text,
           FirstNameTextBox.Text,
           MiddleNameTextBox.Text,
           PhoneNumberTextBox.Text,
           PassportTextBox.Text
       );
            if (string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(PhoneNumber) || string.IsNullOrEmpty(PassportNumber))
            {
                MessageBox.Show("Заполните все обязательные поля.");
            }
            else
            {
                DialogResult = true;
            }
        }
    }
}
