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
    public partial class WebUpdateUser : System.Web.UI.Page
    {
        public byte id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = byte.Parse(Request["id"]);
                UserImpl impl = new UserImpl();
                User user = impl.Get(id);
                txtName.Text = user.Name;
                txtCi.Text = user.Ci;
                txtPApellido.Text = user.LastName;
                txtSApellido.Text = user.SecondLastName;
                Rol.Text = user.role;
                txtUser.Text = user.nameUser;
                txtEmail.Text = user.email;

            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

            try
            {

                id = byte.Parse(Request["id"]);

                UserImpl impl = new UserImpl();
                User user = new User(id, txtCi.Text.Trim(), txtName.Text.Trim(), txtPApellido.Text.Trim(), txtSApellido.Text.Trim(), id, txtUser.Text.Trim(), Rol.Text, txtEmail.Text.Trim());

                UserImpl implUser = new UserImpl();
                DataTable tb = implUser.ExMail(txtEmail.Text);
                SessionClass.SessionCont = int.Parse(tb.Rows[0][0].ToString());

                impl.Update(user);
                Response.Redirect("WebAdmUser.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}