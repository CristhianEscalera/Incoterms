using SolucionesMedicasBilbaoDAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolucionesMedicasBilbaoWeb
{
    public partial class Ingresos : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
            } 

            if (SessionClass.SessionRole != "Ingresos")
            {
                if (SessionClass.SessionRole == "Administrador")
                {
                    Response.Redirect("Default.aspx");
                }
                else if (SessionClass.SessionRole == "Empleado")
                {
                    Response.Redirect("Empleado.aspx");
                }
                else
                {
                    Response.Redirect("WebLogin.aspx");
                }
            }
        }
    }
}