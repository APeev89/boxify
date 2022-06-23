using boxify.Data.Common;
using boxify.Data.ModelsDb;
using boxify.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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



        [Authorize]
        public IActionResult AddToFavorites(string id)
        {
            
            var ad = repo.GetById<Ad>(id);
            var user = userManager.GetUserAsync(User).Result;
            var favoriteAd = repo.All<Favourite>().FirstOrDefault(x => x.AdId == ad.Id && x.UserFavorites.Any(u=>u.UserId==user.Id));


            if (favoriteAd == null)
            {
                favoriteAd = new Favourite
                {
                    AdId = ad.Id,

                };

                UserFavorite userFavorite = new UserFavorite
                {
                    FavoriteId = favoriteAd.Id,
                    UserId = user.Id,
                };

                repo.Add(favoriteAd);
                repo.Add(userFavorite);
            }
            
            repo.SaveChanges();
            return Redirect("/Favorites/ListOfFavorites");
        }
        [Authorize]
        public IActionResult ListOfFavorites()
        {
            IEnumerable<Favourite>? favouriteAds = null;
            var user = userManager.GetUserAsync(User).Result;
            var userFavorites = repo.All<UserFavorite>().Where(x=>x.UserId == user.Id).Select(x=>x.FavoriteId);
            var allFavorites = repo.All<Favourite>().Include(x=>x.Ad).Where(x => userFavorites.Contains(x.Id));
            if (allFavorites.Count() != 0)
            {
                favouriteAds = allFavorites;
            }
            
            return View(new FavoritesViewModel
            {
                FavouriteList = favouriteAds,
            });
        }

        [Authorize]
        public IActionResult RemoveFromFavorites(string id)
        {
            var ad = repo.GetById<Ad>(id);
            var user = userManager.GetUserAsync(User).Result;
            var favoriteAd = repo.All<Favourite>().FirstOrDefault(x => x.AdId == ad.Id && x.UserFavorites.Any(u => u.UserId == user.Id));
            var userFavorite = repo.All<UserFavorite>().FirstOrDefault(x => x.UserId == user.Id && x.FavoriteId == favoriteAd.Id);
            repo.Delete<UserFavorite>(userFavorite);
            repo.Delete<Favourite>(favoriteAd);

            repo.SaveChanges();
            return Redirect("/Favorites/ListOfFavorites");
        }
    }
}
