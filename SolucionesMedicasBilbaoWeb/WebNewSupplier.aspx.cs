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
    public partial class WebNewSupplier : System.Web.UI.Page
    {
        Supplier t;
        SupplierImpl implSupplier;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                t = new Supplier(txtNit.Text.Trim(), txtName.Text.Trim(), txtDireccion.Text.Trim(), ddlPais.SelectedValue+ " " + txtTelefono.Text.Trim(), txtSitioWeb.Text.Trim());
                implSupplier = new SupplierImpl();
                int n = implSupplier.Insert(t);
                if (n > 0)
                {
                    Response.Redirect("WebAdmSupplier.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}