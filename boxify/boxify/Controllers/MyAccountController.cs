using boxify.Data.Common;
using boxify.Data.ModelsDb;
using boxify.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace boxify.Controllers
{
    public class MyAccountController : BaseController
    {
        private readonly IRepository repo;
        private readonly UserManager<IdentityUser> userManager;

        public MyAccountController(IRepository _repo, UserManager<IdentityUser> _userManager)
        {
            repo = _repo;
            userManager = _userManager;
        }

        [Authorize]
        public IActionResult AllMyAds()
        {
            IEnumerable<Ad>? myAdsList = null;
            var user = userManager.GetUserAsync(User).Result;
            var myAds = repo.All<Ad>().Where(x => x.UserId == user.Id);

            if (myAds.Count() != 0)
            {
                myAdsList = myAds;
            }

            return View(new MyAdsViewModel
            {
                MyAdsList = myAdsList,
            });
        }
    }
}
