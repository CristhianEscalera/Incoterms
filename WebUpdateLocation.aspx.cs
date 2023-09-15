using SolucionesMedicasBilbaoDAO;
using SolucionesMedicasBilbaoDAO.Implementacion;
using SolucionesMedicasBilbaoDAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace SolucionesMedicasBilbaoWeb
{
    public partial class WebUpdateLocation : System.Web.UI.Page
    {
        public byte id;
        LocationImpl implLocation;
        Location t;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                implLocation = new LocationImpl();
                cmbMunicipalidad.DataSource = implLocation.CargarCombo().DefaultView;
                cmbMunicipalidad.DataTextField = "Lugar";
                cmbMunicipalidad.DataValueField = "ID";
                cmbMunicipalidad.DataBind();

                implLocation = new LocationImpl();
                cmbCliente.DataSource = implLocation.CargarCombo2().DefaultView;
                cmbCliente.DataTextField = "Cliente";
                cmbCliente.DataValueField = "ID";
                cmbCliente.DataBind();

                id = byte.Parse(Request["id"]);
                LocationImpl impl = new LocationImpl();
                Location cus = impl.Get(id);
                txtNombreLugar.Text = cus.Calle;
                hdnLongitud.Value = cus.Longitud;
                hdnLatitud.Value = cus.Lat;
                txtNombreLugar.Text = cus.Calle;
                txtNum.Text= cus.NumCasa.ToString();
                cmbMunicipalidad.SelectedValue = cus.idMunicipaly.ToString();
                cmbCliente.SelectedValue = cus.idCustomer.ToString();
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

            try
            {

                id = byte.Parse(Request["id"]);

                string selectedValue = cmbMunicipalidad.SelectedValue;
                int Mun = Convert.ToInt32(selectedValue);
                string selectedValue2 = cmbCliente.SelectedValue;
                int Cli = Convert.ToInt32(selectedValue2);

                LocationImpl impl = new LocationImpl();
                Location cus = new Location(id,Cli,Mun,txtNombreLugar.Text.Trim(),int.Parse(txtNum.Text.Trim()),hdnLongitud.Value,hdnLatitud.Value);

                impl.Update(cus);
                Response.Redirect("WebAdmLocation.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}