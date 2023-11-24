using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionesMedicasBilbaoDAO.Interfaces
{
    internal interface IBase<T>
    {
        int Delete(T t);
        int Insert(T t);
        DataTable Select();
        int Update(T t);
    }
}
