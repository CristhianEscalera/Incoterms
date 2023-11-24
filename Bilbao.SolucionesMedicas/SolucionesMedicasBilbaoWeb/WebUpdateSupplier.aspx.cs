using SolucionesMedicasBilbaoDAO;
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
    public partial class WebUpdateSupplier : System.Web.UI.Page
    {
        public int id;
        Supplier t;
        SupplierImpl implSupplier;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = int.Parse(Request["id"]);
                implSupplier = new SupplierImpl();
                byte ID = Convert.ToByte(id);
                Supplier t = implSupplier.Get(ID);
                txtName.Text = t.Nombre;
                txtNit.Text = t.Nit;
                txtSitioWeb.Text = t.Url;
                txtDireccion.Text = t.Locacion;
                txtTelefono.Text = t.Telefono;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

            try
            {
                id = int.Parse(Request["id"]);
                byte ID = Convert.ToByte(id);
                implSupplier = new SupplierImpl();
                t = new Supplier(ID, txtNit.Text.Trim(), txtName.Text.Trim(), txtDireccion.Text.Trim(), txtTelefono.Text.Trim(), txtSitioWeb.Text.Trim());
                int n = implSupplier.Update(t);
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