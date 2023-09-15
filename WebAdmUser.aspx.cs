using SolucionesMedicasBilbaoDAO.Implementacion;
using SolucionesMedicasBilbaoDAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace SolucionesMedicasBilbaoWeb
{
    public partial class WebAdmUser : System.Web.UI.Page
    {
        User t;
        UserImpl implUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            Select();
        }
        void Select()
        {
            try
            {
                implUser = new UserImpl();
                gridData.DataSource = implUser.Select();
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
                UserImpl impl = new UserImpl();
                User user = new User(id);
                impl.Delete(user);
                Select();
            }
        }
        protected void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            // Configura el documento PDF
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();

            // Agrega el contenido del GridView al PDF
            PdfPTable table = new PdfPTable(gridData.Columns.Count-1);
            foreach (TableCell cell in gridData.HeaderRow.Cells)
            {
                table.AddCell(new Phrase(cell.Text));
            }
            foreach (GridViewRow row in gridData.Rows)
            {
                foreach (TableCell cell in row.Cells)
                {
                    table.AddCell(new Phrase(cell.Text));
                }
            }
            pdfDoc.Add(table);

            // Cierra el documento PDF
            pdfDoc.Close();

            // Descarga el PDF generado
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Usuarios.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }
        /*
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            {
                string query = @"SELECT * FROM Person 
                                WHERE firstName LIKE @firstName
                                OR lastName LIKE @lastName 
                                OR SegundoApellido LIKE @secondLastName";
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@firstName", "%" + p.name + "%");
                command.Parameters.AddWithValue("@lastName", "%" + p.LastName + "%");
                command.Parameters.AddWithValue("@SecondLastName", "%" + p.SecondLastName + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Enlazar los resultados al GridView
                gridData.DataSource = dt;
                gridData.DataBind();
            }
        }*/
    }
}