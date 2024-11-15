using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDiveIntoOOP.Part2WpfApp
{
    public class Consultant : IEditable
    {

        public void UpdatePhoneNumber(Client client, string newPhoneNumber, string editorType)
        {
            client.PhoneNumber = newPhoneNumber;
            client.UpdateModificationInfo("PhoneNumber", "Изменение", editorType);
        }

        // Просмотр данных клиента с ограничением на номер паспорта
        public void ViewClientInfo(Client client)
        {
            Console.WriteLine($"Фамилия: {client.LastName}");
            Console.WriteLine($"Имя: {client.FirstName}");
            Console.WriteLine($"Отчество: {client.MiddleName}");
            Console.WriteLine($"Номер телефона: {client.PhoneNumber}");
            Console.WriteLine($"Серия, номер паспорта: {client.GetProtectedPassportNumber()}");
        }

        // Изменение номера телефона клиента
        public void UpdatePhoneNumber(Client client, string newPhoneNumber)
        {
            if (!string.IsNullOrEmpty(newPhoneNumber))
            {
                client.PhoneNumber = newPhoneNumber;
                Console.WriteLine("Номер телефона обновлен.");
            }
            else
            {
                Console.WriteLine("Номер телефона не может быть пустым.");
            }
        }
    }
}
