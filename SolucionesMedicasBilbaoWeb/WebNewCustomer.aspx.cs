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
    public partial class WebNewCustomer : System.Web.UI.Page
    {
        Customer t;
        CustomerImpl implCustomer;
        Person p;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                p = new Person(txtCi.Text.Trim(), txtName.Text.Trim(), txtPApellido.Text.Trim(), txtSApellido.Text.Trim());
                t = new Customer(txtNit.Text.Trim(), txtPhone.Text.Trim(), txtNameBussines.Text.Trim(), txtTitulo.Text.Trim());
                implCustomer = new CustomerImpl();
                implCustomer.Insert(p, t);

                Response.Redirect("WebAdmCustomer.aspx");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}