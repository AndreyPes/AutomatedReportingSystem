using ARS_WebApp.BL.common.Logic;
using System.Web.Mvc;
using ARS_WebApp.BL.common.Infrastructure;

namespace ARS_WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IMediator _mediator =new Mediator();
            return View(_mediator.GetEquipmentData());
        }      
    }
}