using boxify.Data.Common;
using boxify.Data.ModelsDb;
using boxify.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace boxify.Controllers
{
    public class AddController: BaseController
    {
        private readonly IRepository repo;
        private readonly UserManager<IdentityUser> userManager;

        public AddController(IRepository _repo, UserManager<IdentityUser> _userManager)
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
               
            };

            repo.Add(ad);
            repo.SaveChanges();

            return Redirect("/");
        }
    }
}
