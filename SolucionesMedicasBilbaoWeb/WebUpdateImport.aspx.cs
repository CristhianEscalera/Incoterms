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
    public partial class WebUpdateImport : System.Web.UI.Page
    {
        public int id;
        Import t;
        ImportImpl implImport;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                implImport = new ImportImpl();
                cmbDestino.DataSource = implImport.CargarCombo2().DefaultView;
                cmbDestino.DataTextField = "Destino";
                cmbDestino.DataValueField = "ID";
                cmbDestino.DataBind();

                implImport = new ImportImpl();
                cmbOrigen.DataSource = implImport.CargarCombo().DefaultView;
                cmbOrigen.DataTextField = "Origen";
                cmbOrigen.DataValueField = "ID";
                cmbOrigen.DataBind();

                implImport = new ImportImpl();
                cmbProveedor.DataSource = implImport.CargarCombo3().DefaultView;
                cmbProveedor.DataTextField = "Proveedor";
                cmbProveedor.DataValueField = "ID";
                cmbProveedor.DataBind();

                implImport = new ImportImpl();
                DataTable dtEmbarcadores = implImport.CargarCombo4();

                DataRow row = dtEmbarcadores.NewRow();
                row["ID"] = DBNull.Value;
                row["Embarcador"] = "Ninguno";
                dtEmbarcadores.Rows.InsertAt(row, 0);

                cmbEmbarcador.DataSource = dtEmbarcadores;
                cmbEmbarcador.DataTextField = "Embarcador";
                cmbEmbarcador.DataValueField = "ID";
                cmbEmbarcador.DataBind();

                id = int.Parse(Request["id"]);
                ImportImpl impl = new ImportImpl();
                Import imp = impl.Get(id);
                Incoterm.Text = imp.incoterm;
                txtFechaInicio.Text = imp.fechaSalida.ToString("yyyy-MM-dd");
                txtFechaTentativa.Text = imp.fechaTentativa.ToString("yyyy-MM-dd");
                DateTime? fehcaLlegada = imp.fehcaLlegada;
                if (fehcaLlegada.HasValue)
                {
                    txtFechaFin.Text = fehcaLlegada.Value.ToString("yyyy-MM-dd");
                }
                cmbOrigen.SelectedValue = imp.idOrigen.ToString();
                cmbDestino.SelectedValue = imp.idDestino.ToString();
                if (imp.idEmbarcador.HasValue)
                {
                    cmbEmbarcador.SelectedValue = imp.idEmbarcador.ToString();
                }
                else
                {
                    cmbEmbarcador.SelectedValue = DBNull.Value.ToString();
                }
                cmbProveedor.SelectedValue = imp.idProveedor.ToString();
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(Request["id"]);

                DateTime? fechaFin = string.IsNullOrEmpty(txtFechaFin.Text.Trim()) ? (DateTime?)null : DateTime.Parse(txtFechaFin.Text.Trim());

                string selectedValue = cmbOrigen.SelectedValue;
                int id2 = Convert.ToInt32(selectedValue);
                string selectedValue2 = cmbDestino.SelectedValue;
                int id3 = Convert.ToInt32(selectedValue2);
                string selectedValue3 = cmbProveedor.SelectedValue;
                int id4 = Convert.ToInt32(selectedValue3);
                string selectedValue4 = cmbEmbarcador.SelectedValue;
                int? id5 = null;

                if (!string.IsNullOrEmpty(selectedValue4) && selectedValue4 != "Ninguno")
                {
                    id5 = Convert.ToInt32(selectedValue4);
                }

                implImport = new ImportImpl();
                t = new Import(id, DateTime.Parse(txtFechaInicio.Text.Trim()), DateTime.Parse(txtFechaTentativa.Text.Trim()), fechaFin, Incoterm.Text, id2, id3, id5, id4);
                int n = implImport.Update(t);
                if (n > 0)
                {
                    Response.Redirect("WebAdmImport.aspx");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}