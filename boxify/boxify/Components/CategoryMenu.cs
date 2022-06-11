using boxify.Data.Common;
using boxify.Data.ModelsDb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace boxify.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly IRepository repo;
        public CategoryMenu(IRepository _repo)
        {
            repo = _repo;
        }
        public IViewComponentResult Invoke()
        {
            var categories = repo.All<Category>().OrderBy(c => c.Name);

            //List<SelectListItem> cities = categories.Select(x =>
            //new SelectListItem { Value = x.Id, Text = x.Name }).ToList();



            return View(categories);
        }
    }
}
