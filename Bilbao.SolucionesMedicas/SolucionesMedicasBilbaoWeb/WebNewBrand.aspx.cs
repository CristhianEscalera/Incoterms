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
    public partial class WebNewBrand : System.Web.UI.Page
    {
        Brand t;
        BrandImpl implBrand;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {

                t = new Brand(txtName.Text.Trim());
                implBrand = new BrandImpl();
                int n = implBrand.Insert(t);
                if (n > 0)
                {
                    Response.Redirect("WebAdmBrand.aspx");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}