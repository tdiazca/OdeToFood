using OdeToFood.Web.Models;
using System.Configuration;
using System.Web.Mvc; // to build html

namespace OdeToFood.Web.Controllers
{
    public class GreetingController : Controller // View-model: carries info from controller into the View
                                                 // Web application controller = respond to http request by building model and returning a view that rendered that model. For web applications via browser.
                                                 // web API controller = optimised for building APIs. Does not use browser, responds with json or xml. Consumes/ produces json or xml
    {
        // GET: Greeting
        public ActionResult Index(string name)
        {
            var model = new GreetingViewModel(); //build model instance of view model
            model.Name = name ?? "no name";
            model.Message = ConfigurationManager.AppSettings["message"]; // gets message from Web.config file
            return View(model); // a View Model
        }
    }
}