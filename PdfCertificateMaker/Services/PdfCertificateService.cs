using System;
using IronPdf; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PdfCertificateMaker.Services
{
    public class PdfCertificateService
    {
        public void CreatePdfCertificate(string fName, string lName, string certificateName)
        {
            try
            {
                // initialize a renderer from IronPdf (downloaded Nuget)
                var renderer = new IronPdf.ChromePdfRenderer();

                // Html code for the pdf creation
                string htmlCode = $"<h1 style=\"text-align: center;\">Certificate Of Completion in {certificateName}</h1>" +
                                  $"<h3 style=\"text-align: center;\">{fName} {lName}</h3>";

                var certificatePdf = renderer.RenderHtmlAsPdf(htmlCode);

                // Finds Path to download folder
                string downloadsPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "Downloads");

                certificatePdf.SaveAs($"{downloadsPath}/{fName}{lName}CertificateIn{certificateName}.pdf");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Problem with PdfCertificateService...");
            }
        }
    }
}
