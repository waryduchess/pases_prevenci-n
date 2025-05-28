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
    public class PDFGenerator
    {
        public void GenerarPDF(Movimiento mov, string rutaArchivo)
        {
            Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
            PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
            doc.Open();

            // Fuente personalizada
            Font tituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
            Font textoFont = FontFactory.GetFont(FontFactory.HELVETICA, 11);

            // Encabezado con nombre del hotel
            string nombreHotel = string.IsNullOrWhiteSpace(mov.NombreHotel) ? "HOTEL NO DEFINIDO" : mov.NombreHotel.ToUpper();
            Paragraph hotel = new Paragraph(nombreHotel,tituloFont);
            hotel.Alignment = Element.ALIGN_CENTER;
            hotel.SpacingAfter = 10f;
            doc.Add(hotel);

            Paragraph titulo = new Paragraph("PASE DE ENTRADA / SALIDA", tituloFont);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.SpacingAfter = 20f;
            doc.Add(titulo);

            // Información del pase
            doc.Add(new Paragraph($"Folio: {mov.Folio}",textoFont));
            doc.Add(new Paragraph($"Tipo de Movimiento: {mov.TipoMovimiento}", textoFont));
            doc.Add(new Paragraph($"Fecha de Salida: {mov.FechaSalida:dd/MM/yyyy}", textoFont));
            doc.Add(new Paragraph($"Fecha de Regreso: {mov.FechaRegreso:dd/MM/yyyy}", textoFont));
            doc.Add(new Paragraph($"Número de Paquetes: {mov.NumeroPaquetes}", textoFont));
            doc.Add(new Paragraph($"Solicitante: {mov.NombreSolicitante}", textoFont));
            doc.Add(new Paragraph($"Tipo de Persona: {mov.TipoPersona}", textoFont));
            doc.Add(new Paragraph($"Nombre de Seguridad: {mov.FirmaSeguridadNombre}", textoFont));
            doc.Add(new Paragraph(" "));

            // Tabla de artículos
            PdfPTable tabla = new PdfPTable(2);
            tabla.WidthPercentage = 100;
            tabla.SetWidths(new float[] { 2, 4 });

            PdfPCell header1 = new PdfPCell(new Phrase("Nombre del Artículo", textoFont));
            PdfPCell header2 = new PdfPCell(new Phrase("Descripción", textoFont));
            header1.BackgroundColor = header2.BackgroundColor = BaseColor.LIGHT_GRAY;
            tabla.AddCell(header1);
            tabla.AddCell(header2);

            foreach (var art in mov.Articulos)
            {
                tabla.AddCell(new Phrase(art.NombreArticulo, textoFont));
                tabla.AddCell(new Phrase(art.DescripcionArticulo, textoFont));
            }

            doc.Add(tabla);
            doc.Add(new Paragraph(" "));

            // Espacio para firmas
            PdfPTable firmas = new PdfPTable(3);
            firmas.WidthPercentage = 100;
            firmas.SetWidths(new float[] { 1, 1, 1 });
            firmas.SpacingBefore = 30f;

            firmas.AddCell(CeldaFirma("Firma Jefe Departamento", textoFont));
            firmas.AddCell(CeldaFirma("Firma de Autorización", textoFont));
            firmas.AddCell(CeldaFirma("Firma de Seguridad", textoFont));

            doc.Add(firmas);
            doc.Close();
        }

        private PdfPCell CeldaFirma(string titulo, Font font)
        {
            PdfPCell celda = new PdfPCell();
            celda.Border = PdfPCell.NO_BORDER;
            celda.PaddingTop = 20f;

            Paragraph p = new Paragraph("\n\n_________________________\n" + titulo, font);
            p.Alignment = Element.ALIGN_CENTER;
            celda.AddElement(p);

            return celda;
        }
    }

   
        public static class ReporteCarroPDF
        {
        public static void ExportarPaseCarro(PaseCarro pase, string ruta)
        {
            Document doc = new Document(PageSize.A5.Rotate(), 20, 20, 20, 20); // Tarjetón horizontal
            PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
            doc.Open();

            var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
            var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 11);

            PdfPTable tabla = new PdfPTable(1);
            tabla.WidthPercentage = 100;

            void AddCell(string texto, Font font, int align = Element.ALIGN_LEFT)
            {
                PdfPCell cell = new PdfPCell(new Phrase(texto, font))
                {
                    Border = Rectangle.NO_BORDER,
                    HorizontalAlignment = align,
                    Padding = 5
                };
                tabla.AddCell(cell);
            }

            AddCell("TARJETON VEHICULO", titleFont, Element.ALIGN_CENTER);
            AddCell("-----------------------------------------------", normalFont, Element.ALIGN_CENTER);
            AddCell($"FOLIO: {pase.Folio}        FECHA: {pase.Fecha:dd/MM/yyyy}", headerFont);
            AddCell("------------------------------------------------", normalFont);
            AddCell($"CONDUCTOR: {pase.NombreConductor}", normalFont);
            AddCell($"MOTIVO: {pase.MotivoVisita}", normalFont);
            AddCell("------------------------------------------------", normalFont);
            AddCell("VEHÍCULO", headerFont);
            AddCell($"Placas: {pase.Placas}    Marca: {pase.Marca}    Modelo: {pase.Modelo}", normalFont);
            AddCell($"Color: {pase.Color}", normalFont);
            AddCell("------------------------------------------------", normalFont);
            AddCell($"AUTORIZACIÓN SEGURIDAD: {pase.FirmaSeguridadNombre}", normalFont);

            doc.Add(tabla);
            doc.Close();
        }
        }
    }

