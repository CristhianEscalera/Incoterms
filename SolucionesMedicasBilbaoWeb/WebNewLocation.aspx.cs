using SolucionesMedicasBilbaoDAO;
using SolucionesMedicasBilbaoDAO.Implementacion;
using SolucionesMedicasBilbaoDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace SolucionesMedicasBilbaoWeb
{
    public partial class WebAdmLocation : System.Web.UI.Page
    {
        Location t;
        LocationImpl implLocation;
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
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedValue = cmbMunicipalidad.SelectedValue;
                int id = Convert.ToInt32(selectedValue);
                string selectedValue2 = cmbCliente.SelectedValue;
                int id2 = Convert.ToInt32(selectedValue2);

                t = new Location(id2, id,txtNombreLugar.Text.Trim(), int.Parse(txtNum.Text.Trim()), hdnLongitud.Value, hdnLatitud.Value);
                implLocation = new LocationImpl();
                int n = implLocation.Insert(t);
                if (n > 0)
                {
                    Response.Redirect("WebAdmLocation.aspx");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}