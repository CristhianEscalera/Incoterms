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
    public partial class WebAdmUser : System.Web.UI.Page
    {
        User t;
        UserImpl implUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            Select();
        }
        void Select()
        {
            try
            {
                implUser = new UserImpl();
                gridData.DataSource = implUser.Select();
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
                UserImpl impl = new UserImpl();
                User user = new User(id);
                impl.Delete(user);
                Select();
            }
        }
    }
}