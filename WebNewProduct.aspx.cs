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
    public partial class WebNewProduct : System.Web.UI.Page
    {
        Product t;
        ProductImpl productImp;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                productImp= new ProductImpl();
                cmbBrand.DataSource = productImp.CargarCombo().DefaultView;

                cmbBrand.DataTextField = "Name";
                cmbBrand.DataValueField = "ID";
                cmbBrand.DataBind();

                productImp = new ProductImpl();
                cmbCategory.DataSource = productImp.CargarCombo2().DefaultView;
                cmbCategory.DataTextField = "Name";
                cmbCategory.DataValueField = "ID";
                cmbCategory.DataBind();
            }
        }
        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedValue = cmbBrand.SelectedValue;
                int id = Convert.ToInt32(selectedValue);
                string selectedValue2 = cmbCategory.SelectedValue;
                int id2 = Convert.ToInt32(selectedValue2);

                t = new Product(txtName.Text.Trim(),double.Parse(txtBasePrice.Text.Trim()),int.Parse(TxtStock.Text.Trim()),TxtMeasureUnit.Text.Trim(),TxtModel.Text.Trim(),id,id2);
                productImp = new ProductImpl();
                int n = productImp.Insert(t);
                if (n > 0)
                {
                    Response.Redirect("WebAdmProduct.aspx");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}