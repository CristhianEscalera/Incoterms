using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.pdf;
using iTextSharp.text;
using SolucionesMedicasBilbaoDAO;
using SolucionesMedicasBilbaoDAO.Implementacion;
using SolucionesMedicasBilbaoDAO.Model;


namespace SolucionesMedicasBilbaoWeb
{
    public partial class WebAdmSupplier : System.Web.UI.Page
    {
        Supplier t;
        SupplierImpl implSupplier;
        protected void Page_Load(object sender, EventArgs e)
        {
            Select();
        }
        void Select()
        {
            try
            {
                implSupplier = new SupplierImpl();
                gridData.DataSource = implSupplier.Select();
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
                SupplierImpl impl = new SupplierImpl();
                byte ID = Convert.ToByte(id);
                Supplier supplier = new Supplier(ID);
                impl.Delete(supplier);
                Select();
            }
        }

        protected void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            // Crear el documento PDF
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
            pdfDoc.Open();

            // Agregar el contenido del GridView al PDF
            PdfPTable table = new PdfPTable(gridData.Columns.Count-1);
            foreach (TableCell cell in gridData.HeaderRow.Cells)
            {
                PdfPCell pdfCell = new PdfPCell(new Phrase(cell.Text));
                table.AddCell(pdfCell);
            }
            foreach (GridViewRow row in gridData.Rows)
            {
                foreach (TableCell cell in row.Cells)
                {
                    PdfPCell pdfCell = new PdfPCell(new Phrase(cell.Text));
                    table.AddCell(pdfCell);
                }
            }
            pdfDoc.Add(table);

            // Cerrar el documento PDF
            pdfDoc.Close();

            // Descargar el PDF generado
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Proveedores.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(memoryStream.ToArray());
            Response.End();
        }


    }
}