using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace boxify.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
     
    }
}
