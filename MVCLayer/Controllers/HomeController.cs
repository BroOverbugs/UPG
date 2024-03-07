using Application.Interfaces;
using Domain.Entities;
using Infastructure.Data;
using Microsoft.AspNetCore.Mvc;
using MVCLayer.Models;
using System.Diagnostics;

namespace MVCLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMonitorService _monitorService;

        public HomeController(ILogger<HomeController> logger,
                              IMonitorService monitorService)
        {
            _logger = logger;
            _monitorService = monitorService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Acsessories()
        {
            return View();
        }
        public IActionResult AppleProducts()
        {
            return View();
        }
        public IActionResult PowerSupplies()
        {
            return View();
        }
        public IActionResult Decor()
        {
            return View();
        }
        public IActionResult GamingConsoles()
        {
            return View();
        }
        public IActionResult Gamepads()
        {
            return View();
        }
        public IActionResult Sborka()
        {
            return View();
        }
        public IActionResult Keyboards()
        {
            return View();
        }

        public IActionResult Colons()
        {
            return View();
        }
        public IActionResult Kits()
        {
            return View();
        }
        public IActionResult Cases()
        {
            
            return View();
        }
        public IActionResult MousePads()
        {
            return View();
        }
        public IActionResult Armchairs()
        {
            return View();
        }
        public IActionResult Kronshteyns()
        {
            return View();
        }
        public IActionResult Coolers()
        {
            return View();
        }
        public IActionResult Microfones()
        {
            return View();
        }
        public IActionResult Mouses()
        {
            return View();
        }
        public async Task<IActionResult> Monitors()
        {
            var monitors = await _monitorService.GetAllAsync();
            return View(monitors);
            //return View();
        }
        public IActionResult SSDorHDD()
        {
            return View();
        }
        public IActionResult Headphones()
        {
            return View();
        }
        public IActionResult Laptops()
        {
            return View();
        }
        public IActionResult Glasses()
        {
            return View();
        }
        public IActionResult RAM()
        {
            return View();
        }
        public IActionResult Tables()
        {
            return View();
        }
        public IActionResult UPS()
        {
            return View();
        }
        public IActionResult WebCam()
        {
            return View();
        }
        public IActionResult WiFiRouter()
        {
            return View();
        }
        public IActionResult Item()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
