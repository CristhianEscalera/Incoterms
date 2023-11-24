using SolucionesMedicasBilbaoDAO.Implementacion;
using SolucionesMedicasBilbaoDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolucionesMedicasBilbaoWeb
{
    public partial class WebUpdateCustomer : System.Web.UI.Page
    {
        public byte id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = byte.Parse(Request["id"]);
                CustomerImpl impl = new CustomerImpl();
                Customer cus = impl.Get(id);
                txtName.Text = cus.Name;
                txtCi.Text = cus.Ci;
                txtPApellido.Text = cus.LastName;
                txtSApellido.Text = cus.SecondLastName;
                txtNameBussines.Text = cus.Nombre;
                txtNit.Text = cus.Nit;
                txtPhone.Text = cus.Telefono;
                txtTitulo.Text = cus.Titulos;
            }
        }


        protected void btnModificar_Click(object sender, EventArgs e)
        {

            try
            {

                id = byte.Parse(Request["id"]);

                CustomerImpl impl = new CustomerImpl();
                Customer cus = new Customer(id, txtCi.Text.Trim(), txtName.Text.Trim(), txtPApellido.Text.Trim(), txtSApellido.Text.Trim(), id,txtNit.Text.Trim(), txtPhone.Text.Trim(), txtNameBussines.Text.Trim(), txtTitulo.Text.Trim());

                impl.Update(cus);
                Response.Redirect("WebAdmCustomer.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}