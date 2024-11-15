using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace DeepDiveIntoOOP.Part2WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Client> clients;
        private string currentRole;
        private Consultant consultant;
        private Manager manager;
        private const string FilePath = "clients.txt";

        public MainWindow()
        {
            InitializeComponent();
            clients = new ObservableCollection<Client>();
            ClientDataGrid.ItemsSource = clients;
        }

        private void RoleSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RoleSelector.SelectedItem is ComboBoxItem selectedRole)
            {
                currentRole = selectedRole.Content.ToString();
                if (currentRole == "Консультант")
                {
                    consultant = new Consultant();
                    AddClientButton.Visibility = Visibility.Collapsed;
                }
                else if (currentRole == "Менеджер")
                {
                    manager = new Manager();
                    AddClientButton.Visibility = Visibility.Visible;
                }
            }
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            if (currentRole == "Менеджер" && manager != null)
            {
                var newClientWindow = new AddClientWindow();
                if (newClientWindow.ShowDialog() == true)
                {
                    var newClient = manager.AddClient(
                        newClientWindow.LastName,
                        newClientWindow.FirstName,
                        newClientWindow.MiddleName,
                        newClientWindow.PhoneNumber,
                        newClientWindow.PassportNumber
                    );
                    clients.Add(newClient);
                    MessageBox.Show("Новый клиент добавлен.");
                }
            }
        }

        private void LoadClients_Click(object sender, RoutedEventArgs e)
        {
            clients.Clear(); // Очистка текущего списка клиентов
            if (File.Exists(FilePath))
            {
                try
                {
                    foreach (var line in File.ReadAllLines(FilePath))
                    {
                        // Проверяем, что строка содержит нужное количество частей
                        var data = line.Split('#');
                        if (data.Length == 5)
                        {
                            var client = new Client(data[0], data[1], data[2], data[3], data[4]);
                            clients.Add(client); // Добавление клиента в коллекцию
                        }
                        else
                        {
                            MessageBox.Show("Ошибка в формате данных: " + line);
                        }
                    }
                    MessageBox.Show("Клиенты успешно загружены.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка при чтении файла: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Файл clients.txt не найден.");
            }
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllLines(FilePath, clients.Select(c => $"{c.LastName}#{c.FirstName}#{c.MiddleName}#{c.PhoneNumber}#{c.GetProtectedPassportNumber()}"));
            MessageBox.Show("Изменения сохранены.");
        }

        private void SortClients_Click(object sender, RoutedEventArgs e)
        {
            var sortedClients = clients.OrderBy(c => c.LastName).ToList();
            clients.Clear();
            foreach (var client in sortedClients)
            {
                clients.Add(client);
            }
        }

        private void ClientDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var client = (Client)e.Row.Item;
            if (currentRole == "Консультант" && consultant != null)
            {
                if (e.Column.Header.ToString() == "Телефон")
                {
                    var textBox = e.EditingElement as TextBox;
                    if (!string.IsNullOrEmpty(textBox?.Text))
                    {
                        consultant.UpdatePhoneNumber(client, textBox.Text);
                    }
                    else
                    {
                        MessageBox.Show("Номер телефона не может быть пустым.");
                        e.Cancel = true;
                    }
                }
                else
                {
                    MessageBox.Show("Консультант может редактировать только номер телефона.");
                    e.Cancel = true;
                }
            }
            else if (currentRole == "Менеджер" && manager != null)
            {
                // Менеджер может изменять все поля, поэтому тут дополнительная логика не нужна
            }
        }

    }
}

