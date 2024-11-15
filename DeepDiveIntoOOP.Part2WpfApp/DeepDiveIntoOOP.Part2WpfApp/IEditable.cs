using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDiveIntoOOP.Part2WpfApp
{
    public interface IEditable
    {
        void UpdatePhoneNumber(Client client, string newPhoneNumber, string editorType);
    }

    public interface IManagerEditable : IEditable
    {
        void UpdateClientInfo(Client client, string lastName, string firstName, string middleName, string phoneNumber, string passportNumber, string editorType);
        Client AddClient(string lastName, string firstName, string middleName, string phoneNumber, string passportNumber);
    }
}
