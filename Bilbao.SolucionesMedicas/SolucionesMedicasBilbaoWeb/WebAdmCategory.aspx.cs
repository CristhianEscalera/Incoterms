﻿using SolucionesMedicasBilbaoDAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

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
        protected void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
            pdfDoc.Open();
            PdfPTable table = new PdfPTable(gridData.Columns.Count - 1);
            foreach (TableCell cell in gridData.HeaderRow.Cells)
            {
                if (cell.Text != "Acciones")
                {
                    PdfPCell pdfCell = new PdfPCell(new Phrase(cell.Text));
                    table.AddCell(pdfCell);
                }
            }
            foreach (GridViewRow row in gridData.Rows)
            {
                foreach (TableCell cell in row.Cells)
                {
                    if (gridData.HeaderRow.Cells[row.Cells.GetCellIndex(cell)].Text != "Acciones")
                    {
                        PdfPCell pdfCell = new PdfPCell(new Phrase(cell.Text));
                        table.AddCell(pdfCell);
                    }
                }
            }
            pdfDoc.Add(table);
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Categorias.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(memoryStream.ToArray());
            Response.End();
        }

    }
}