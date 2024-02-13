using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Configuration;
using System.Security.Policy;
using WebApplication1.Areas.AccountCategory.Models;

namespace WebApplication1.Areas.AccountCategory.Controllers
{
    //[CheckAccess]
    [Area("AccountCategory")]
    [Route("AccountCategory/[controller]/[action]")]
    public class AccountCategoryController : Controller
    {
        public IConfiguration Configuration;
        public AccountCategoryController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        private HttpClient client = new HttpClient();
        [HttpPost]
        public IActionResult AccountCategoryListPage()
        {
            MultipartFormDataContent dataContent = new MultipartFormDataContent();

            dataContent.Add("InstituteCode");
            dataContent.Add("PageOffset");
            dataContent.Add("PageSize");
            List<AccountCategoryModel> accountcategorymodels = new List<AccountCategoryModel>();
            HttpResponseMessage response = client.PostAsync($"https://testapi.gncms.in/AccountCategorySelectPage/CommonAccount/getAccountCategorySelectPage").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                dynamic jsonObject = JsonConvert.DeserializeObject(data);
                var dataOfObject = jsonObject.data;
                var extDataJason = JsonConvert.SerializeObject(dataOfObject, Formatting.Indented);
                accountcategorymodels = JsonConvert.DeserializeObject<List<AccountCategoryModel>>(extDataJason);

            }
            return View("AccountCategoryListPage", accountcategorymodels);
            //return View();
        }
    }
}
