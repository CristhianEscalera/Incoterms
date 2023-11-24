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
    public partial class WebNewImport : System.Web.UI.Page
    {
        Import t;
        ImportImpl implImport;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                implImport= new ImportImpl();
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
            }

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime? fechaFin = string.IsNullOrEmpty(txtFechaFin.Text.Trim()) ? (DateTime?)null : DateTime.Parse(txtFechaFin.Text.Trim());

                string selectedValue = cmbOrigen.SelectedValue;
                int id = Convert.ToInt32(selectedValue);
                string selectedValue2 = cmbDestino.SelectedValue;
                int id2 = Convert.ToInt32(selectedValue2);
                string selectedValue3 = cmbProveedor.SelectedValue;
                int id3 = Convert.ToInt32(selectedValue3);
                string selectedValue4 = cmbEmbarcador.SelectedValue;
                int? id4 = null;

                if (!string.IsNullOrEmpty(selectedValue4) && selectedValue4 != "Ninguno")
                {
                    id4 = Convert.ToInt32(selectedValue4); 
                }

                t = new Import(DateTime.Parse(txtFechaInicio.Text.Trim()), DateTime.Parse(txtFechaTentativa.Text.Trim()), fechaFin, Incoterm.Text, id, id2, id4, id3);
                implImport = new ImportImpl();
                int n = implImport.Insert(t);
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