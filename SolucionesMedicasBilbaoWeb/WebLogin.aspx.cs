using SolucionesMedicasBilbaoDAO.Implementacion;
using SolucionesMedicasBilbaoDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

namespace SolucionesMedicasBilbaoWeb
{
    public partial class WebLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionClass.SessionCont = 0;
            SessionClass.SessionUserName = null;
            SessionClass.SessionRole = null;
            SessionClass.StatusPass = 0;
        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                UserImpl implUser = new UserImpl();
                DataTable tb = implUser.Login(txtUser.Text, txtPassword.Text);
                if (tb.Rows.Count > 0)
                {
                    SessionClass.SessionCont = int.Parse(tb.Rows[0][0].ToString());
                    SessionClass.SessionUserName = tb.Rows[0][1].ToString();
                    SessionClass.SessionRole = tb.Rows[0][2].ToString();
                    SessionClass.StatusPass = int.Parse(tb.Rows[0][3].ToString());

                    if (SessionClass.StatusPass == 1)
                    {
                        Response.Redirect("WebReset.aspx");
                    }
                    else
                    {
                        if (SessionClass.SessionRole == "Administrador")
                        {
                            Response.Redirect("Default.aspx");
                        }
                        else if (SessionClass.SessionRole == "Empleado")
                        {
                            Response.Redirect("Empleado.aspx");
                        }
                        else if (SessionClass.SessionRole == "Ingresos")
                        {
                            Response.Redirect("Ingresos.aspx");
                        }
                    }
                }
                else
                {

                    txtError.InnerText = "Ingrese Usuario/Contraseña correcta";

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}