using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using BIBF.Test.Controllers;

namespace BIBF.Test.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : TestControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
