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
    public partial class WebNewCountry : System.Web.UI.Page
    {
        Country t;
        CountryImpl implCountry;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {

                t = new Country(txtName.Text.Trim());
                implCountry = new CountryImpl();
                int n = implCountry.Insert(t);
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