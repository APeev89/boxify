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
        private readonly ILogger<HomeController> logger;
        private readonly IRepository repo;

        public HomeController(ILogger<HomeController> _logger, IRepository _repo)
        {
            logger = _logger;
            repo = _repo;
        }

        public IActionResult Index()
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