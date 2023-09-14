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
    public partial class WebAdmCustomer : System.Web.UI.Page
    {
        Customer t;
        CustomerImpl implCustomer;
        protected void Page_Load(object sender, EventArgs e)
        {
            Select();
        }

        void Select()
        {
            try
            {
                implCustomer = new CustomerImpl();
                gridData.DataSource = implCustomer.Select();
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
                CustomerImpl impl = new CustomerImpl();
                byte ID = Convert.ToByte(id);
                Customer customer = new Customer(ID);
                impl.Delete(customer);
                Select();
            }
        }
    }
}