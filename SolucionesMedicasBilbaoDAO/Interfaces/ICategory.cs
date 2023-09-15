using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolucionesMedicasBilbaoDAO.Interfaces;

namespace SolucionesMedicasBilbaoDAO
{
    internal interface ICategory:IBase<Category>
    {
        Category Get(Byte id);

        DataTable CargarCombo();

    }
}
