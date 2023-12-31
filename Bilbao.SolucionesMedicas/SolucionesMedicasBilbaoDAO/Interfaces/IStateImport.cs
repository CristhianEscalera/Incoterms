﻿using SolucionesMedicasBilbaoDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionesMedicasBilbaoDAO.Interfaces
{
    internal interface IStateImport:IBase<StateImport>
    {
        StateImport Get(int id);
        DataTable CargarCombo();
    }
}
