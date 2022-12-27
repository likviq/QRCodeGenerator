using Net.Codecrete.QrCodeGenerator;
using QRCode.Models;
using System.Text;

namespace QRCode.Services
{
    public class QRCodeService : IQRCodeService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public QRCodeService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// create image file in web root (/QRCode/qrcode.svg). So you can open it in browser
        /// </summary>
        public Task<string> CreateQRCodeFile(QrCode qrCode)
        {
            var qrSvg = qrCode.ToSvgString(10);

            string path = Path.Combine(_webHostEnvironment.WebRootPath, "QRCode");
            if (!Directory.Exists(path))
            {
                 Directory.CreateDirectory(path);
            }

            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "QRCode/qrcode.svg");
            System.IO.File.WriteAllText(filePath, qrSvg, Encoding.UTF8);
            string fileName = Path.GetFileName(filePath);

            return Task.FromResult(fileName);
        }

        /// <summary>
        /// This function create qr code and return name of the saved qrCode file
        /// </summary>
        public Task<string> GenerateQRCode(QRCodeModel qRCodeModel)
        {
            var qr = QrCode.EncodeText(qRCodeModel.QRCodeText, QrCode.Ecc.Medium);
            return CreateQRCodeFile(qr);
        }
    }
}
