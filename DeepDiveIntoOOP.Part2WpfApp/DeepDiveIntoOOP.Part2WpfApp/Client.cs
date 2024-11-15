using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDiveIntoOOP.Part2WpfApp
{
    public class Client
    {
        public string LastName { get; set; } // Удалили private set
        public string FirstName { get; set; } // Удалили private set
        public string MiddleName { get; set; } // Удалили private set
        public string PhoneNumber { get; set; }
        private string PassportNumber { get; set; }


        // Дополнительные поля для хранения истории изменений
        public DateTime LastModified { get; private set; }
        public string ModifiedField { get; private set; }
        public string ModificationType { get; private set; }
        public string Editor { get; private set; }

        public Client(string lastName, string firstName, string middleName, string phoneNumber, string passportNumber)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            PhoneNumber = phoneNumber;
            PassportNumber = passportNumber;
        }

        // Метод для скрытого представления паспортного номера для консультанта
        public string GetProtectedPassportNumber()
        {
            return string.IsNullOrEmpty(PassportNumber) ? "" : "******************";
        }

        public string GetFullPassportNumber()
        {
            return PassportNumber;
        }

        // Добавляем метод для изменения номера паспорта
        public void SetPassportNumber(string passportNumber)
        {
            PassportNumber = passportNumber;
        }

        public void UpdateModificationInfo(string field, string type, string editor)
        {
            LastModified = DateTime.Now;
            ModifiedField = field;
            ModificationType = type;
            Editor = editor;
        }
    }
}
