using iTextSharp.text.pdf; // PDF işlemleri için kütüphane ekledim
using iTextSharp.text;
using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

public static class PdfCreater // PDF oluşturma sınıfı
{
    public class TextItem // metin eklemek için özellikler
    {
        public float X { get; set; } // X koordinatı
        public float Y { get; set; } // Y koordinatı
        public string Content { get; set; } // Metin içeriği

        public TextItem(float x, float y, string content) // Metin öğesi oluşturuyoruz
        {
            X = x;
            Y = y;
            Content = content;
        }
    }
    public static void Create(string TcNo, string HastaAdı, string HastaSoyadı, string doktorAdı, 
        string doktorSoyadı, string tarih, string ilaçlar, string tani, string aciklama)
    {
        try
        {
            string inputFile = @"C:\Users\Resul Karakoç\source\repos\Medipol_Hospital\Medipol_Hospital\PdfCreater\reçete.pdf"; // Giriş PDF dosyası yolubu bulms

            PdfReader reader = new PdfReader(inputFile); // PDF dosyasını oku

            using (SaveFileDialog saveFileDialog = new SaveFileDialog()) // Kaydetme işlemi 
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*"; // Dosya filteleri 
                saveFileDialog.Title = "PDF Dosyasını Kaydet"; // Diyaloğun başlığı 
                saveFileDialog.FileName = HastaAdı + "_" + HastaSoyadı + "_Reçete.pdf"; // Varsayılandosya adı ama sor kullanıcıya

                if (saveFileDialog.ShowDialog() == DialogResult.OK) // Kullanıcı kaydetmeyi onaylarsa 
                {
                    string outputFile = saveFileDialog.FileName; // Çıktı PDF dosyası yolu

                    Document document = new Document(); // Yeni bir pdF oluştur devamke
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outputFile, FileMode.Create)); // PDF yazdırıcı olusşrurt

                    document.Open(); //Belgeyi aç

                    BaseFont bf = BaseFont.CreateFont("c:/windows/fonts/comic.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED); // Yazıtipi belirle
                    Font font = new Font(bf, 12, Font.NORMAL); //Yazı tipini ayarla

                    PdfContentByte cb = writer.DirectContent; //Pdf içeriğine yazmak için nesne oluştur

                    List<TextItem> textItems = new List<TextItem>() // eklencek öğeller
                    {
                        new TextItem(100f, 540f, TcNo), 
                        new TextItem(100f, 600f, HastaAdı + " " + HastaSoyadı), 
                        new TextItem(400f, 550f, doktorAdı + " " + doktorSoyadı), 
                        new TextItem(400f, 620f, tarih), 
                        new TextItem(240f, 435f, ilaçlar), 
                        new TextItem(100f, 500f, tani), 
                        new TextItem(100f, 200f, aciklama)
                    };

                    PdfImportedPage importedPage = writer.GetImportedPage(reader, 1); // pdf'in ilk sayfasını al
                    cb.AddTemplate(importedPage, 0, 0); //seçilen pdfe ekle 

                    foreach (var item in textItems) // Metin öğelerini PDF'e ekle
                    {
                        float x = item.X;
                        float y = item.Y;
                        string content = item.Content;

                        cb.BeginText(); // Metni başlat
                        cb.SetFontAndSize(bf, 12); // Yazı tipini ayarla
                        cb.SetTextMatrix(x, y); // Metin nereye gelicek?
                        cb.ShowText(content); // Metni PDF'e ekle
                        cb.EndText(); //bitir
                    }
                    document.Close(); //Belgeyi kapat
                    reader.Close(); //Okuyucuyu kapat

                    MessageBox.Show("PDF dosyası başarıyla oluşturuldu ve kaydedildi.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information); //b ilgilendirme mesajı
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); // Hata mesajı
        }
    }
}


