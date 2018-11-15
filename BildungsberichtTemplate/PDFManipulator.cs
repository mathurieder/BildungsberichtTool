using iText.Forms;
using iText.Forms.Fields;
using iText.Kernel.Font;
using iText.Kernel.Pdf;

namespace BildungsberichtTemplate
{
    public class PDFManipulator
    {
        private PdfDocument pdfDoc;

        public PDFManipulator(string src, string dest) {
            pdfDoc = new PdfDocument(new PdfReader(src), new PdfWriter(dest));
            pdfDoc.GetDocumentInfo();
        }

        public void Close() {
            pdfDoc.Close();
        }

        public void SetValue(string key, string value) {
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
            var i = form.GetDefaultAppearance();
            var i2 = form.GetDefaultJustification();
            var i3 = form.GetDefaultResources();
            PdfFormField field = form.GetFormFields()[key];

            if (field is PdfTextFormField)
            {
                PdfTextFormField pdfTextFormField = (PdfTextFormField)field;
                ///pdfTextFormField.SetDefaultAppearance("/Titillium 6 Tf 0 g");
                if (pdfTextFormField.GetFieldName().GetValue().Contains("Beurteilung"))
                {
                    pdfTextFormField.SetDefaultAppearance("/Helv 6 Tf 0 g");
                }
                
                pdfTextFormField.SetValue(value);
            }
            else
            {
                field.SetValue(value);
            }
        }
    }
}
