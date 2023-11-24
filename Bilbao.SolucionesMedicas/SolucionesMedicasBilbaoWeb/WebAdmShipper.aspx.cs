﻿using System;
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
                    PdfPCell pdfCell = new PdfPCell(new Phrase(GetCellValue(cell.Text), GetFont()));
                    table.AddCell(pdfCell);
                }
            }
            foreach (GridViewRow row in gridData.Rows)
            {
                foreach (TableCell cell in row.Cells)
                {
                    if (gridData.HeaderRow.Cells[row.Cells.GetCellIndex(cell)].Text != "Acciones")
                    {
                        PdfPCell pdfCell = new PdfPCell(new Phrase(GetCellValue(cell.Text), GetFont()));
                        table.AddCell(pdfCell);
                    }
                }
            }
            pdfDoc.Add(table);
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Embarcadores.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(memoryStream.ToArray());
            Response.End();
        }

        private Font GetFont()
        {
            return FontFactory.GetFont("Arial", 12, Font.NORMAL);
        }

        private string GetCellValue(string cellText)
        {
            cellText = HttpUtility.HtmlDecode(cellText);
            return cellText.Replace("&nbsp;", " ");
        }

    }
}