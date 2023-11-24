using SolucionesMedicasBilbaoDAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolucionesMedicasBilbaoWeb
{
    public partial class WebAdmCategory : System.Web.UI.Page
    {
        Category t;
        CategoryImpl implCategory;
        protected void Page_Load(object sender, EventArgs e)
        {
            Select();
        }

        void Select()
        {
            try
            {
                implCategory = new CategoryImpl();
                gridData.DataSource = implCategory.Select();
                gridData.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void gridData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                CategoryImpl impl = new CategoryImpl();
                byte ID = Convert.ToByte(id);
                Category category = new Category(ID);
                impl.Delete(category);
                Select();
            }
        }

    }
}