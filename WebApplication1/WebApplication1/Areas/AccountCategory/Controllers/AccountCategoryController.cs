using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.AccountCategory.Controllers
{
    //[CheckAccess]
    [Area("AccountCategory")]
    [Route("AccountCategory/[controller]/[action]")]
    public class AccountCategoryController : Controller
    {
        public IActionResult AccountCategoryListPage()
        {
            return View();
        }
    }
}
