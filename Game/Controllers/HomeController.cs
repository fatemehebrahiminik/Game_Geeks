using Game_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Game.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetNewPerson()
        {
            try
            { 
                return Json(new PersonService().GetPerson(), JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {
                //insert error to log services
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult CalculatePointGame(int boxId, int imgId)
        {
            try
            {
                return  Json(new PersonService().GetPoint(boxId, imgId), JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {
                //insert error to log services
                return  Json(null, JsonRequestBehavior.AllowGet);
            }
        }
    }
}