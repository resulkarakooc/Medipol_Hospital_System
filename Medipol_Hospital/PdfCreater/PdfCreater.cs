using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Medipol_Hospital.PdfCreater
{
    public class PdfCreater
    {
        public class TextItem
        {
            public float X { get; set; }
            public float Y { get; set; }
            public string Content { get; set; }
            public TextItem(float x, float y, string content)
            {
                X = x;
                Y = y;
                Content = content;
            }
        }

        public static void Create(string TcNo, string HastaAdı, string HastaSoyadı, string doktorAdı, string doktorSoyadı, string tarih, string ilaçlar, string tani, string aciklama)
        {
            try
            {
                string inputFile = @"C:\Users\Resul Karakoç\source\repos\Medipol_Hospital\Medipol_Hospital\PdfCreater\reçete.pdf";

                PdfReader reader = new PdfReader(inputFile);

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                    saveFileDialog.Title = "PDF Dosyasını Kaydet";
                    saveFileDialog.FileName = HastaAdı+"_"+HastaSoyadı+"_Reçete.pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string outputFile = saveFileDialog.FileName;

                        Document document = new Document();
                        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outputFile, FileMode.Create));

                        document.Open();

                        BaseFont bf = BaseFont.CreateFont("c:/windows/fonts/comic.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        Font font = new Font(bf, 12, Font.NORMAL);


                        PdfContentByte cb = writer.DirectContent;

                        List<TextItem> textItems = new List<TextItem>()
                        {
                             new TextItem(100f, 540f,TcNo),
                             new TextItem(100f, 600f, HastaAdı+" "+HastaSoyadı),
                             new TextItem(400f, 550f, doktorAdı+" "+doktorSoyadı),
                             new TextItem(400f, 620f, tarih),
                             new TextItem(240f, 435f,ilaçlar),
                             new TextItem(100f, 500f,tani),
                             new TextItem(100f, 200f,aciklama)
                        };

                        PdfImportedPage importedPage = writer.GetImportedPage(reader, 1);
                        cb.AddTemplate(importedPage, 0, 0);

                        foreach (var item in textItems)
                        {
                            float x = item.X;
                            float y = item.Y;
                            string content = item.Content;

                            cb.BeginText();
                            cb.SetFontAndSize(bf, 12);
                            cb.SetTextMatrix(x, y);
                            cb.ShowText(content);
                            cb.EndText();
                        }
                        document.Close();
                        reader.Close();

                        MessageBox.Show("PDF dosyası başarıyla oluşturuldu ve kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}



