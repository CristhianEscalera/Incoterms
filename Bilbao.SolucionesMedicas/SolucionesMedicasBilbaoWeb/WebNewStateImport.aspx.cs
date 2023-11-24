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
    public partial class WebNewStateImport : System.Web.UI.Page
    {
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
            }

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {

                string selectedValue2 = cmbPais.SelectedValue;
                byte id2 = Byte.Parse(selectedValue2);

                t = new StateImport(txtName.Text.Trim(),id2);
                implStateImport = new StateImportImpl();
                int n = implStateImport.Insert(t);
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