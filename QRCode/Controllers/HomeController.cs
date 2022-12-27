using Microsoft.AspNetCore.Mvc;
using Net.Codecrete.QrCodeGenerator;
using QRCode.Models;
using QRCode.Services;
using System.Diagnostics;
using System.Text;

namespace QRCode.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IQRCodeService _qrcodeService;
        public HomeController(ILogger<HomeController> logger, IQRCodeService qrcodeService)
        {
            _logger = logger;
            _qrcodeService = qrcodeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CreateQRCode()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateQRCode(QRCodeModel generateQRCode)
        {

            string fileName = await _qrcodeService.GenerateQRCode(generateQRCode);
            
            string imageUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" + "/QRCode/" + fileName;     
            ViewBag.QrCodeUri = imageUrl;
            
            return View();
        }
    }
}