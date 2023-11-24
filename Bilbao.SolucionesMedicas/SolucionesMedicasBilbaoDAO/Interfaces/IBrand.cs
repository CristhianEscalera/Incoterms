using SolucionesMedicasBilbaoDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionesMedicasBilbaoDAO.Interfaces
{
    internal interface IBrand : IBase<Brand>
    {
        Brand Get(Byte id);

        DataTable CargarCombo();
    }
}
