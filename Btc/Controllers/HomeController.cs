using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Btc.Algoritm;
using Btc.Modeles;
using DAL.Model;

namespace Btc.Controllers
{
    public class HomeController : Controller
    {
        private DbEntities _context;
        [HttpGet]
        public ActionResult Index()
        {
            var result = new TotalUnionDto();
            return View(result);
        }

        [HttpPost]
        public ActionResult Index(TotalUnionDto totalUnionDto)
        {
            
           
            
            var gradientCalculate = new GradientCalculate(totalUnionDto);
            var result = gradientCalculate.GetResult();

            return View(result);
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