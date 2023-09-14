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
    public partial class WebUpdateStateImport : System.Web.UI.Page
    {
        public int id;
        StateImport t;
        StateImportImpl implStateImport;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                implStateImport = new StateImportImpl();
                cmbPais.DataSource = implStateImport.CargarCombo().DefaultView;
                cmbPais.DataTextField = "País";
                cmbPais.DataValueField = "ID";
                cmbPais.DataBind();

                id = int.Parse(Request["id"]);
                implStateImport = new StateImportImpl();
                StateImport t = implStateImport.Get(id);
                txtName.Text = t.Name;
                cmbPais.SelectedValue = t.IdCountry.ToString();
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(Request["id"]);

                string selectedValue2 = cmbPais.SelectedValue;
                byte id2 = Byte.Parse(selectedValue2);

                implStateImport = new StateImportImpl();
                t = new StateImport(id, txtName.Text.Trim(),id2);
                int n = implStateImport.Update(t);
                if (n > 0)
                {
                    Response.Redirect("WebAdmStateImport.aspx");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}