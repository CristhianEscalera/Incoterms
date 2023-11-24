using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SolucionesMedicasBilbaoDAO;
using SolucionesMedicasBilbaoDAO.Implementacion;
using SolucionesMedicasBilbaoDAO.Model;

namespace SolucionesMedicasBilbaoWeb
{
    public partial class WebAdmSupplier : System.Web.UI.Page
    {
        Supplier t;
        SupplierImpl implSupplier;
        protected void Page_Load(object sender, EventArgs e)
        {
            Select();
        }
        void Select()
        {
            try
            {
                implSupplier = new SupplierImpl();
                gridData.DataSource = implSupplier.Select();
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
                SupplierImpl impl = new SupplierImpl();
                byte ID = Convert.ToByte(id);
                Supplier supplier = new Supplier(ID);
                impl.Delete(supplier);
                Select();
            }
        }

    }
}