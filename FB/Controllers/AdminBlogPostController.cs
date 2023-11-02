using Microsoft.AspNetCore.Mvc;

namespace FB.Controllers
{
    public class AdminBlogPostController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
    }
}
