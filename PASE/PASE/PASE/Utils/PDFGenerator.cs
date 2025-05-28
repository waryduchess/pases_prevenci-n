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
            public static void ExportarPaseCarro(PaseCarro pase, string rutaArchivo)
            {
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
            doc.Open();

            Font titulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
            Font texto = FontFactory.GetFont(FontFactory.HELVETICA, 12);

            // Si tienes logo
            string rutaLogo = @"C:\Ruta\A\TuLogo.png"; // Ajusta esta ruta
            if (File.Exists(rutaLogo))
            {
                Image logo = Image.GetInstance(rutaLogo);
                logo.ScaleAbsolute(100, 100);
                logo.Alignment = Element.ALIGN_LEFT;
                doc.Add(logo);
            }

            doc.Add(new Paragraph("Hotel Alegría - Pase de Vehículo", titulo));
            doc.Add(new Paragraph(" ", texto));

            doc.Add(new Paragraph($"Folio: {pase.Folio}", texto));
            doc.Add(new Paragraph($"Fecha: {pase.Fecha}", texto));
            doc.Add(new Paragraph($"Nombre del Conductor: {pase.NombreConductor}", texto));
            doc.Add(new Paragraph($"Placas: {pase.Placas}", texto));
            doc.Add(new Paragraph($"Marca: {pase.Marca}", texto));
            doc.Add(new Paragraph($"Modelo: {pase.Modelo}", texto));
            doc.Add(new Paragraph($"Color: {pase.Color}", texto));
            doc.Add(new Paragraph($"Motivo de Visita: {pase.MotivoVisita}", texto));
            doc.Add(new Paragraph($"Firma Seguridad: {pase.FirmaSeguridadNombre}", texto));

            doc.Close();
        }
        }
    }

