using boxify.Data.Common;
using boxify.Data.ModelsDb;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace boxify.Controllers
{
    public class FavoritesController : BaseController
    {
        private readonly IRepository repo;
        private readonly UserManager<IdentityUser> userManager;
        public FavoritesController(IRepository _repo, UserManager<IdentityUser> _userManager)
        {
            repo = _repo;
            userManager = _userManager;
        }

       

        public IActionResult AddToFavorites(string id)
        {
            
            var ad = repo.GetById<Ad>(id);
            var favoriteAd = repo.All<Favourite>().Where(x => x.AdId == ad.Id).FirstOrDefault();
            if (favoriteAd == null)
            {
                favoriteAd = new Favourite
                {
                    AdId = id
                };
            }
            var user = userManager.GetUserAsync(User).Result;

            UserFavorite userFavorite = new UserFavorite
            {
                FavoriteId = favoriteAd.Id,
                UserId = user.Id,
            };

            repo.Add(favoriteAd);
            repo.Add(userFavorite);
            repo.SaveChanges();
            return Redirect("/Favorites/ListOfFavorites");
        }
        public IActionResult ListOfFavorites(string id)
        {
            
            return View();
        }

    }
}
