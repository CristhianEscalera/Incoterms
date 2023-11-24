using SolucionesMedicasBilbaoDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionesMedicasBilbaoDAO.Interfaces
{
    internal interface ILocation : IBase<Location>
    {
        Location Get(Byte id);
        DataTable CargarCombo();
        DataTable CargarCombo2();
    }
}
