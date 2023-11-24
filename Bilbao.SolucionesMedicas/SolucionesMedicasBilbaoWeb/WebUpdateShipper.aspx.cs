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
    public partial class WebUpdateShipper : System.Web.UI.Page
    {
        Shipper t;
        ShipperImpl implShipper;
        public int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = int.Parse(Request["id"]);
                ShipperImpl impl = new ShipperImpl();
                Shipper shipper = impl.Get(id);
                txtName.Text = shipper.Nombre;
                txtPrecio.Text = shipper.Precio.ToString();
                txtLocalizacion.Text = shipper.Locacion;
                Envio.Text = shipper.Tipo;

            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

            try
            {
                id = int.Parse(Request["id"]);
                implShipper = new ShipperImpl();
                t = new Shipper(id, txtName.Text.Trim(), decimal.Parse(txtPrecio.Text.Trim()), txtLocalizacion.Text.Trim(), Envio.Text);
                int n = implShipper.Update(t);
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