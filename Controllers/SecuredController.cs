using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BlogMongoDB.Controllers
{
    [Authorize]
    public class SecuredController : Controller
    {
        public IActionResult Index() => View();
    }
}
