using SolucionesMedicasBilbaoDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolucionesMedicasBilbaoWeb
{
    public partial class WebUpdateProduct : System.Web.UI.Page
    {
        public byte id;
        ProductImpl productImpl;
        Product t;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                productImpl = new ProductImpl();
                cmbBrand.DataSource = productImpl.CargarCombo().DefaultView;
                cmbBrand.DataTextField = "Name";
                cmbBrand.DataValueField = "ID";
                cmbBrand.DataBind();

                productImpl = new ProductImpl();
                cmbCategory.DataSource = productImpl.CargarCombo2().DefaultView;
                cmbCategory.DataTextField = "Name";
                cmbCategory.DataValueField = "ID";
                cmbCategory.DataBind();

                id = byte.Parse(Request["id"]);
                ProductImpl impl = new ProductImpl();
                Product cus = impl.Get(id);
                txtName.Text = cus.Name;
                txtPrecio.Text = cus.BasePrice.ToString();
                TxtStock.Text = cus.Stock.ToString();
                TxtMeasureUnit.Text = cus.MeasureUnit;
                cmbBrand.SelectedValue = cus.IdBrand.ToString();
                cmbCategory.SelectedValue = cus.IdCategory.ToString();
                TxtModel.Text = cus.Model;
            }
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {

            try
            {
                id = byte.Parse(Request["id"]);

                string selectedValue = cmbBrand.SelectedValue;
                int marca = Convert.ToInt32(selectedValue);
                string selectedValue2 = cmbCategory.SelectedValue;
                int categoria = Convert.ToInt32(selectedValue2);

                ProductImpl impl = new ProductImpl();
                Product cus = new Product(id, txtName.Text.Trim(), double.Parse(txtPrecio.Text.Trim()), int.Parse(TxtStock.Text.Trim()), TxtMeasureUnit.Text.Trim(), TxtModel.Text.Trim(), marca, categoria);

                impl.Update(cus);
                Response.Redirect("WebAdmProduct.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}