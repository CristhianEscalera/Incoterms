using SolucionesMedicasBilbaoDAO.Implementacion;
using SolucionesMedicasBilbaoDAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolucionesMedicasBilbaoWeb
{
    public partial class WebAdmStateImport : System.Web.UI.Page
    {
        StateImport t;
        StateImportImpl implStateImport;
        protected void Page_Load(object sender, EventArgs e)
        {
            Select();
        }

        void Select()
        {
            try
            {
                implStateImport = new StateImportImpl();
                gridData.DataSource = implStateImport.Select();
                gridData.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void gridData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                StateImportImpl impl = new StateImportImpl();
                StateImport stateImport = new StateImport(id);
                impl.Delete(stateImport);
                Select();
            }
        }
    }
}