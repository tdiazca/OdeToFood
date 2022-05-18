using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData db;

        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }

        // GET: Restaurants
        [HttpGet]
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create() // doesnt create a restaurant. It created a form for the user to create a restaurant
        {
            return View();
        }

        [HttpPost] // this create only responds to a http post!, so after user adds info in the created form
        [ValidateAntiForgeryToken] // attribute for controller action below
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid) // a name has been provided (checked by data annotation in Restaurant.cs)
            {
                db.Add(restaurant);
                TempData["Message"] = "You have saved the restaurant!";
                return RedirectToAction("Details", new { id = restaurant.Id }); // redirect to "Details" view for this restaurant id
            }
            return View();

        }

        [HttpGet]
        public ActionResult Edit(int id) // doesnt create a restaurant. It created a form for the user to create a restaurant
        {
            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model); // view that returns that restaurant like the model
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Update(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View(restaurant);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}