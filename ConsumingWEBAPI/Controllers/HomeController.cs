using ConsumingWebAPI.Models;
using ConsumingWebAPI.Factory;
using ConsumingWebAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using AspCoreModel;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using System.Reflection;

namespace ConsumingWebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<MySettingsModel> appSettings;
        private IConfiguration configuration;
        public HomeController(
            IConfiguration configuration,
             IOptions<MySettingsModel> _appSettings)
        {
            appSettings = _appSettings;
            ApplicationSettings.WebApiUrl = configuration["MySettings:WebApiBaseUrl"];
            this.configuration = configuration;

        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        public async Task<IActionResult> Index()
        {
            var data = await AoiClientFactory.Instance.GetUsers();
            var response = await SaveUser();
            return View();

        }
        private async Task<JsonResult> SaveUser()
        {
            var model = new UserModel()
            {
                Id = 0,
                Name= "Kavi",
                EmailId= "kavi@wew.com",
                Mobile= "98989898",
                Address= "Gokarna",
                IsActive = true
            };
        var response = await AoiClientFactory.Instance.SaveUser(model);
        return Json(response);
        }
    }
}