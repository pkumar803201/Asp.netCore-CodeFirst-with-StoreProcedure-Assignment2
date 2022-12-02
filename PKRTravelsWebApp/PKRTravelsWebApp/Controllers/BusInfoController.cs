using Microsoft.AspNetCore.Mvc;
using PKRTravelsWebApp.Models;
using PKRTravelsWebApp.Services;

namespace PKRTravelsWebApp.Controllers
{
    public class BusInfoController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly IBusInfoService _busInfoService;

        public BusInfoController(IConfiguration configuration, IBusInfoService busInfoService)
        {
            _configuration = configuration;
            _busInfoService = busInfoService;
        }



        public IActionResult Index()
        {
            BusInfoVM model = new BusInfoVM();
            model.BusInfoList = _busInfoService.GetBusInfoList().ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BusInfo busInfo)
        {
            BusInfoVM model = new BusInfoVM();
           /*
            string url = Request.Headers["Referer"].ToString();*/
            string result = string.Empty;
           
                result = _busInfoService.InsertBusInfo(busInfo);
           
            if (result == "Save Successfully!")
            {
                TempData["SuccessMsg"] = "Save Successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMsg"] = result;
                return RedirectToAction("Index");
            }
            
            return View(busInfo);

        }

    }
}
