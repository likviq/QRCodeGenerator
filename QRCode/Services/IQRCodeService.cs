using Net.Codecrete.QrCodeGenerator;
using QRCode.Models;

namespace QRCode.Services
{
    public interface IQRCodeService
    {
        Task<string> GenerateQRCode(QRCodeModel qRCodeModel);
        Task<string> CreateQRCodeFile(QrCode qrCode);
    }
}
