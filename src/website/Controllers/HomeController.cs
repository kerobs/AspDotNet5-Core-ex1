using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using website.Models;
using website.Services;
using website.Models.ManageViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICouncilRepository _councilService;
        private readonly ICouncilVisitRepository _councilVisitService;
   
        public HomeController(ICouncilRepository councilService, ICouncilVisitRepository councilVisitService)
        {
            _councilService = councilService;
            _councilVisitService = councilVisitService;
        }

        public IActionResult Index()
        {
            IEnumerable<Council> olist = _councilService.getAllCouncils();
            HomePageViewModel model = new HomePageViewModel();
            model.councilList = olist;
            model.cVisitModel = null;
            ViewBag.ShowPopUP = false;
            ViewBag.Success = false;
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult Index(HomePageViewModel model)
        {
            IEnumerable<Council> olist = _councilService.getAllCouncils();
            model.councilList = olist;
            ViewBag.ShowPopUP = true;
            ViewBag.Success = false;

            if (model.cVisitModel == null)
            {
                if (model.CouncilId > 0)
                {
                    Council cObj = _councilService.getCouncilById(model.CouncilId);
                    model.AuthorityName = cObj.AuthorityName;

                    CouncilVisit ob = new CouncilVisit();
                    ob.CouncilId = model.CouncilId;                                        
                    ob.UpdatedBy = HttpContext.User.Identity.Name;
                    model.cVisitModel = ob;

                    ViewBag.ShowPopUP = true;
                }
            }
            else
            {
                model.cVisitModel.UpdatedOn = DateTime.Now;
                if (_councilVisitService.AddUpdateCouncilVisit(model.cVisitModel))
                {
                    ViewBag.Success = true;
                }
            }
            return View(model);
        }

        public IActionResult Report()
        {
            return View();
        }

        [HttpPost]
        public void GetReport()
        {
            _councilVisitService.GetLocalAuthorityDoubleBookingStats(HttpContext);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
