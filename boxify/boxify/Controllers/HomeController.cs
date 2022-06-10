using boxify.Data.Common;
using boxify.Data.ModelsDb;
using boxify.Models;
using boxify.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace boxify.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IRepository _repo;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
           // _repo = repo;
        }

        public IActionResult Index()
        {
            //var homeViewModel = new HomeViewModel
            //{
            //    NewAds = _repo.All<Ad>(),
            //};
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
    }
}