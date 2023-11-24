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
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
            }
            if (SessionClass.SessionRole != "Administrador")
            {
                if (SessionClass.SessionRole == "Ingresos")
                {
                    Response.Redirect("Ingresos.aspx");
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