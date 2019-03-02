using System.Web.Mvc;
using LiveTagsSearch.Models;

namespace LiveTagsSearch.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "LiveTagsSearch project 2019";

            return View();
        }

//        [ChildActionOnly]  
        public ActionResult EmployeeLogin()  
        {  
            RouteModel model = new RouteModel(); 
            return PartialView("RoutePartialView", model);  
        }  
        
        public ActionResult Contact()
        {
            ViewBag.Message = "For any bugs, submit a pull request to the official repo";

            return View();
        }
    }
}