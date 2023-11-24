using SolucionesMedicasBilbaoDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolucionesMedicasBilbaoWeb
{
    public partial class WebNewCategory : System.Web.UI.Page
    {
        public int id;
        Category t;
        CategoryImpl implCategory;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            { 
                id = int.Parse(Request["id"]);
                implCategory = new CategoryImpl();
                byte ID = Convert.ToByte(id);
                Category t = implCategory.Get(ID);
                txtName.Text = t.Name;
                txtDescription.Text = t.Description;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                    id = int.Parse(Request["id"]);
                    byte ID = Convert.ToByte(id);
                    implCategory = new CategoryImpl();
                    t = new Category(ID, txtName.Text.Trim(), txtDescription.Text.Trim());
                    int n = implCategory.Update(t);
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