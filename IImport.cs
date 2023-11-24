using SolucionesMedicasBilbaoDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionesMedicasBilbaoDAO.Interfaces
{
    internal interface IImport:IBase<Import>
    {
        Import Get(int id);
        DataTable CargarCombo();
        DataTable CargarCombo2();
        DataTable CargarCombo3();
        DataTable CargarCombo4();
    }
}
