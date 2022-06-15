using boxify.Data.Common;
using boxify.Data.ModelsDb;
using boxify.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace boxify.Controllers
{
    public class AdController: BaseController
    {
        private readonly IRepository repo;
        private readonly UserManager<IdentityUser> userManager;

        public AdController(IRepository _repo, UserManager<IdentityUser> _userManager)
        {
            repo = _repo;
            userManager = _userManager;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreateAdViewModel model)
        {

            var category = repo.All<Category>().FirstOrDefault(x => x.Name == model.Category);
                // First way to take a user
            //var userName = User.Identity.Name;
            //var user = userManager.Users.FirstOrDefault(x => x.UserName == userName);
                // Second way to take a user
            var user = userManager.GetUserAsync(User).Result;


            Ad ad = new Ad()
            {
                Name = model.Name,
                ImgUrl = model.ImgUrl,
                Price = model.Price,
                PhoneNumber = model.PhoneNumber,
                City = model.City,
                IsActive = true,
                CategoryId = category.Id,
                UserId = user.Id,
                Description = model.Description,
                isFavorite = false,
               
            };

            repo.Add(ad);
            repo.SaveChanges();

            return Redirect("/");
        }
        public IActionResult Details(string id)
        {
            var ad = repo.GetById<Ad>(id);
            if (ad == null)
            {
                return NotFound();
            }

            var user = userManager.GetUserAsync(User).Result;
            var favorite = repo.All<Favourite>().FirstOrDefault(x => x.AdId == ad.Id);

            if (favorite != null)
            {
                var currentAd = repo.All<UserFavorite>().FirstOrDefault(x => (x.UserId == user.Id) && (x.FavoriteId == favorite.Id));

                if (currentAd != null)
                {
                    ad.isFavorite = true;
                }

            }


            return View(ad);
        }

       

        public IActionResult List(string category)
        {
            IEnumerable<Ad> ads;
            string currentCategory;

            if (category == null)
            {
                ads = repo.All<Ad>().OrderBy(x => x.DateFrom);
                currentCategory = "All ads";
            }
            else
            {
                ads = repo.All<Ad>().Where(x => x.Category.Name == category).OrderBy(x => x.DateFrom);
                currentCategory = repo.All<Category>().FirstOrDefault(x => x.Name == category)?.Name;
            }


            return View(new AdsListViewModel
            {
                Ads = ads,
                CurrentCategory = currentCategory
            });
        }
    }
}
