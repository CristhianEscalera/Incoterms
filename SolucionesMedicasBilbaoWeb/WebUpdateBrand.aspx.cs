using SolucionesMedicasBilbaoDAO;
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
    public partial class WebUpdateBrand : System.Web.UI.Page
    {
        public int id;
        Brand t;
        BrandImpl implBrand;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id = int.Parse(Request["id"]);
                implBrand = new BrandImpl();
                byte ID = Convert.ToByte(id);
                Brand t = implBrand.Get(ID);
                txtName.Text = t.Name;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(Request["id"]);
                byte ID = Convert.ToByte(id);
                implBrand = new BrandImpl();
                t = new Brand(ID, txtName.Text.Trim());
                int n = implBrand.Update(t);
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