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
    public partial class WebNewShipper : System.Web.UI.Page
    {
        Shipper t;
        ShipperImpl implShipper;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                t = new Shipper(txtName.Text.Trim(), decimal.Parse(txtPrecio.Text.Trim()), txtLocalizacion.Text.Trim(), Envio.Text);
                implShipper = new ShipperImpl();
                int n = implShipper.Insert(t);
                if (n > 0)
                {
                    Response.Redirect("WebAdmShipper.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}