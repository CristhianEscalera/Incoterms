using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SolucionesMedicasBilbaoDAO;
using SolucionesMedicasBilbaoDAO.Implementacion;
using SolucionesMedicasBilbaoDAO.Model;

namespace SolucionesMedicasBilbaoWeb
{
    public partial class WebAdmShipper : System.Web.UI.Page
    {
        Shipper t;
        ShipperImpl implShipper;

        protected void Page_Load(object sender, EventArgs e)
        {
            Select();
        }

        void Select()
        {
            try
            {
                implShipper = new ShipperImpl();
                gridData.DataSource = implShipper.Select();
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
                ShipperImpl impl = new ShipperImpl();
                Shipper shipper = new Shipper(id);
                impl.Delete(shipper);
                Select();
            }
        }
    }
}