using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Medipol_Hospital.PdfCreater
{
    public class PdfCreater
    {

        public void create()
        {
            // SaveFileDialog kullanarak kullanıcıya dosya kaydetme diyalogu göster
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            saveFileDialog.Title = "Save PDF File";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // PDF oluştur
                CreatePdf(saveFileDialog.FileName);
            }
        }


        public void CreatePdf(string filePath)
        {




            // Document nesnesi oluştur
            Document doc = new Document();
            try
            {
                // PdfWriter nesnesi oluştur ve dosyayı aç
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                // PDF'ye içerik ekle
                doc.Add(new Paragraph("Bu bir PDF belgesidir."));
                doc.Add(new Paragraph("Aşağıdaki alanları doldurun:"));

                // Değiştirilebilir alanlar ekle
                PdfFormField field = PdfFormField.CreateTextField(writer, false, false, 50);
                field.FieldName = "name";
                field.SetWidget(new Rectangle(100, 750, 300, 770), PdfAnnotation.HIGHLIGHT_INVERT);
                writer.AddAnnotation(field);

                doc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF oluşturulurken bir hata oluştu: " + ex.Message);
            }
        }
    }
}
