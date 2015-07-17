using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//===========================
using iTextSharp.text;
using iTextSharp.text.pdf;
//===========================

namespace BauchladenProgrammServer.Klassen
{
    public class PDFCreator
    {
        private Document doc;


        // ===========================================================================================================================================================
        // Kann sein, dass er die iTextSharp.dll nich findet, da du die bei dir vllt noch installieren musst, ka ob des mit auf github geladen wird.
        // Falls dies der Fall ist oben im Menü auf Extras ->NuGet-Paket-Manager -> Paket-Manager-Konsole
        // in der oberen Leiste von der Konsole noch des Projekt in der Projektmappe auswählen (habs hier ma für beide installiert)
        // und dann "Install-Package iTextSharp-LGPL" eingeben (ohne " ) und mit Enter bestätigen, kurz warten und fertig!
        // hier gibts nich Tutorials, falls du andres zeug noch brauchst: http://www.mikesdotnetting.com/Article/80/create-pdfs-in-asp-net-getting-started-with-itextsharp
        // ===========================================================================================================================================================

        public PDFCreator()
        {
            // neues Dokument erstellen
            doc = new Document();
            

            // Schriftart festlegen, Standardmäßig ist hier  Helvetica, 12pt, black, Normal festgelegt
            BaseFont courier = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, false);
            iTextSharp.text.Font cou = new iTextSharp.text.Font(courier, 12, 0, iTextSharp.text.Color.BLACK);

            // Pfad festlegen und Speichern
            string path = @"C:\test.pdf";
            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
        }

        public void createSimpleExampleTable()
        {
            doc.Open();

            doc.Add(new Paragraph("Ich bn ein Text\n\n")); // Text hinzufügen


            // Tabelle mit 4 Spalten erstellen und Ausrichtung festlegen
            PdfPTable table = new PdfPTable(4); 
            table.HorizontalAlignment = 0; // 0 = Links, 1 = Mitte, 2 = Rechts

            // "Überschriften" Zelle einfügen
            PdfPCell cell = new PdfPCell(new Phrase("Auszahlung"));
            cell.Colspan = 4;
            cell.HorizontalAlignment = 1;            
            table.AddCell(cell);

            // Neue Zellen hinzufügen
            table.AddCell(new Phrase("ID"));
            table.AddCell(new Phrase("Vorname"));
            table.AddCell(new Phrase("Name"));
            table.AddCell(new Phrase("Betrag"));

            // Beispielzellen einfügen
            for (int i = 0; i < 3; i++)
            {
                table.AddCell(i.ToString());
                table.AddCell("x" + i);
                table.AddCell("y" + i);
                table.AddCell("50.0");
            }
            
            // Tabelle zum PDF hinzufügen und PDf Dokument schließen
            doc.Add(table);

            doc.Close();
        }
    }
}
