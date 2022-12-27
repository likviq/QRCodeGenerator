using System.ComponentModel.DataAnnotations;

namespace QRCode.Models
{
    public class QRCodeModel
    {
        [Display(Name = "Enter QR Code Text")]
        public string QRCodeText { get; set; }
    }
}
