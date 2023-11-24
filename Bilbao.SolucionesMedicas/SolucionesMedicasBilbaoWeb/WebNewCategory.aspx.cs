using SolucionesMedicasBilbaoDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolucionesMedicasBilbaoWeb
{
    public partial class WebNewCategory1 : System.Web.UI.Page
    {

        Category t;
        CategoryImpl implCategory;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {

                t = new Category(txtName.Text.Trim(), txtDescription.Text.Trim());
                implCategory = new CategoryImpl();
                int n = implCategory.Insert(t);
                if (n > 0)
                {
                    Response.Redirect("WebAdmCategory.aspx");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}