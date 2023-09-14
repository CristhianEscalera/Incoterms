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
    public partial class WebUpdateCountry : System.Web.UI.Page
    {
        public int id;
        Country t;
        CountryImpl implCountry;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = int.Parse(Request["id"]);
                implCountry = new CountryImpl();
                byte ID = Convert.ToByte(id);
                Country t = implCountry.Get(ID);
                txtName.Text = t.Name;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(Request["id"]);
                byte ID = Convert.ToByte(id);
                implCountry = new CountryImpl();
                t = new Country(ID, txtName.Text.Trim());
                int n = implCountry.Update(t);
                if (n > 0)
                {
                    Response.Redirect("WebAdmCountry.aspx");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}