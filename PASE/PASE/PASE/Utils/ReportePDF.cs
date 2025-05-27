using iTextSharp.text;
using iTextSharp.text.pdf;
using PASE.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PASE.Utils
{
    public static class ReportePDF
    {
        public static void ExportarResumen(List<Movimiento> movimientos, string ruta)
        {
            Document doc = new Document(PageSize.A4.Rotate(), 30, 30, 20, 20);
            PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
            doc.Open();

            Font tituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
            Font textoFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);

            Paragraph titulo = new Paragraph("REPORTE DE MOVIMIENTOS", tituloFont);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.SpacingAfter = 20f;
            doc.Add(titulo);

            PdfPTable tabla = new PdfPTable(7);
            tabla.WidthPercentage = 100;
            tabla.SetWidths(new float[] { 1.5f, 2, 2, 2, 1.5f, 2.5f, 2 });

            // Encabezados
            string[] headers = { "Folio", "Tipo", "Salida", "Regreso", "#Paq", "Solicitante", "Tipo Persona" };
            foreach (var h in headers)
            {
                PdfPCell cell = new PdfPCell(new Phrase(h, textoFont));
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                tabla.AddCell(cell);
            }

            foreach (var mov in movimientos)
            {
                tabla.AddCell(new Phrase(mov.Folio, textoFont));
                tabla.AddCell(new Phrase(mov.TipoMovimiento, textoFont));
                tabla.AddCell(new Phrase(mov.FechaSalida.ToShortDateString(), textoFont));
                tabla.AddCell(new Phrase(mov.FechaRegreso.ToShortDateString(), textoFont));
                tabla.AddCell(new Phrase(mov.NumeroPaquetes.ToString(), textoFont));
                tabla.AddCell(new Phrase(mov.NombreSolicitante, textoFont));
                tabla.AddCell(new Phrase(mov.TipoPersona, textoFont));
            }

            doc.Add(tabla);
            doc.Close();
        }
    }
}
