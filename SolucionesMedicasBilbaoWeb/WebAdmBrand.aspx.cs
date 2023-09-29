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
    public partial class WebAdmBrand : System.Web.UI.Page
    {
        Brand t;
        BrandImpl implBrand;
        protected void Page_Load(object sender, EventArgs e)
        {
            Select();
        }

        void Select()
        {
            try
            {
                implBrand = new BrandImpl();
                gridData.DataSource = implBrand.Select();
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
                BrandImpl impl = new BrandImpl();
                byte ID = Convert.ToByte(id);
                Brand brand = new   Brand(ID);
                impl.Delete(brand);
                Select();
            }
        }
    }
}