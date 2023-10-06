using SolucionesMedicasBilbaoDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionesMedicasBilbaoDAO.Interfaces
{
    internal interface IUser:IBase<User>
    {
        DataTable Login(string userName, string password);
        int UpdatePassword(User t);
        User Get(Byte id);
        User Mail();
        DataTable ExMail(string emailEx);

        DataTable Login2(string userName);
        void Insert(Person p, User u);
    }
}
