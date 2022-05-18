using OdeToFood.Data.Services;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class HomeController : Controller
    {
        IRestaurantData db;
        public HomeController(IRestaurantData db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            var model = db.GetAll(); // Ienumerable of a restaurant
            return View(model); // return View for Index, restaurants in a list
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}