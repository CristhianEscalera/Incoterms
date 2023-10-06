using SolucionesMedicasBilbaoDAO.Interfaces;
using SolucionesMedicasBilbaoDAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionesMedicasBilbaoDAO.Interfaces
{
    internal interface IPerson:IBase<Person>
    {
        Person Get(Byte id);
    }
}
