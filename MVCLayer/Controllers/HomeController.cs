using Application.Interfaces;

using Microsoft.AspNetCore.Mvc;
using MVCLayer.Models;
using System.Diagnostics;

namespace MVCLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccessoriesService _accessoriesService;
        private readonly IArmchairsService _armchairsService;
        private readonly ICoolerService _coolerService;
        private readonly IDrivesService _drivesService;
        private readonly IGamingBuildsService _gamingBuildsService;
        private readonly IHeadphonesService _headphonesService;
        private readonly IHousingService _housingService;
        private readonly IKeyboardService _keyboardService;
        private readonly ILaptopService _laptopService;
        private readonly IMiceService _miceService;
        private readonly IMonitorService _monitorService;
        private readonly IMousePadsService _mousePadsService;
        private readonly IPowerSuppliesService _powerSuppliesService;
        private readonly IRAMService _ramservice;
        private readonly ITablesForGamersService _tablesForGamersService;

        public HomeController(ILogger<HomeController> logger,
                                IAccessoriesService accessoriesService,
                                IArmchairsService armchairsService,
                                ICoolerService coolerService,
                                IDrivesService drivesService,
                                IGamingBuildsService gamingBuildsService,
                                IHeadphonesService headphonesService,
                                IHousingService housingService,
                                IKeyboardService keyboardService,
                                ILaptopService laptopService,
                                IMiceService miceService,
                                IMonitorService monitorService,
                                IMousePadsService mousePadsService,
                                IPowerSuppliesService powerSuppliesService,
                                IRAMService ramservice,
                                ITablesForGamersService tablesForGamersService
                                )
        {
            _logger = logger;
            _accessoriesService = accessoriesService;
            _armchairsService = armchairsService;
            _coolerService = coolerService;
            _drivesService = drivesService;
            _gamingBuildsService = gamingBuildsService;
            _headphonesService = headphonesService;
            _housingService = housingService;
            _keyboardService = keyboardService;
            _laptopService = laptopService;
            _miceService = miceService;
            _monitorService = monitorService;
            _mousePadsService = mousePadsService;
            _powerSuppliesService = powerSuppliesService;
            _ramservice = ramservice;
            _tablesForGamersService = tablesForGamersService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Acsessories()
        {
            var accessories = await _accessoriesService.GetAccessoriesAsync();
            return View(accessories);
        }
        public async Task<IActionResult> AppleProducts()
        {
            var appleProducts = await _accessoriesService.GetAccessoriesAsync();
            return View(appleProducts);
        }
        public async Task<IActionResult> PowerSupplies()
        {
            var powerSupplies = await _powerSuppliesService.GetPowerSuppliesAsync();
            return View(powerSupplies);
        }
        public async Task<IActionResult> Decor()
        {
            var decors = await _accessoriesService.GetAccessoriesAsync();
            return View(decors);
        }
        public async Task<IActionResult> GamingConsoles()
        {
            var gamingConsoles = await _accessoriesService.GetAccessoriesAsync();
            return View(gamingConsoles);
        }
        public async Task<IActionResult> Gamepads()
        {
            var gamePads = await _accessoriesService.GetAccessoriesAsync();
            return View(gamePads);
        }
        public async Task<IActionResult> Sborka()
        {
            var sborka = await _gamingBuildsService.GetGamingBuildsAsync();
            return View(sborka);
        }
        public async Task<IActionResult> Keyboards()
        {
            var keyboards = await _keyboardService.GetAllAsync();
            return View(keyboards);
        }

        public async Task<IActionResult> Colons()
        {
            var colons = await _accessoriesService.GetAccessoriesAsync();
            return View(colons);
        }
        public async Task<IActionResult> Kits()
        {
            var kits = await _accessoriesService.GetAccessoriesAsync();
            return View(kits);
        }
        public async Task<IActionResult> Cases()
        {
            var cases = await _housingService.GetAllAsync();
            return View(cases);
        }
        public async Task<IActionResult> MousePads()
        {
            var mousePads = await _mousePadsService.GetMousePadsAsync();
            return View(mousePads);
        }
        public async Task<IActionResult> Armchairs()
        {
            var armchair = await _armchairsService.GetArmchairsAsync();
            return View(armchair);
        }
        public async Task<IActionResult> Kronshteyns()
        {
            var kronshteyn = await _accessoriesService.GetAccessoriesAsync();
            return View(kronshteyn);
        }
        public async Task<IActionResult> Coolers()
        {
            var coolers = await _coolerService.GetCoolersAsync();
            return View(coolers);
        }
        public async Task<IActionResult> Microfones()
        {
            var microphones = await _accessoriesService.GetAccessoriesAsync();
            return View(microphones);
        }
        public async Task<IActionResult> Mouses()
        {
            var mouses = await _miceService.GetAllAsync();
            return View(mouses);
        }
        public async Task<IActionResult> Monitors()
        {
            var monitors = await _monitorService.GetAllAsync();
            return View(monitors);
            
        }
        public async Task<IActionResult> SSDorHDD()
        {
            var drives = await _drivesService.GetDrivesAllAsync();
            return View(drives);
        }
        public async Task<IActionResult> Headphones()
        {
            var headphones = await _headphonesService.GetHeadphonesAsync();
            return View(headphones);
        }
        public async Task<IActionResult> Laptops()
        {
            var laptops = await _laptopService.GetAllAsync();
            return View(laptops);
        }
        public async Task<IActionResult> Glasses()
        {
            var glasses = await _accessoriesService.GetAccessoriesAsync();
            return View(glasses);
        }
        public async Task<IActionResult> RAM()
        {
            var ram = await _ramservice.GetRAMAsync();
            return View(ram);
        }
        public async Task<IActionResult> Tables()
        {
            var tables = await _tablesForGamersService.GetTablesForGamersAsync();
            return View(tables);
        }
        public async Task<IActionResult> UPS()
        {
            var ups = await _accessoriesService.GetAccessoriesAsync();
            return View(ups);
        }
        public async Task<IActionResult> WebCam()
        {
            var webcameras = await _accessoriesService.GetAccessoriesAsync();
            return View(webcameras);
        }
        public async Task<IActionResult> WiFiRouter()
        {
            var wifiRouter = await _accessoriesService.GetAccessoriesAsync();
            return View(wifiRouter);
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
