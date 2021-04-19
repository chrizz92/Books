using Books.Core.Contracts;
using Books.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            HomeIndexViewModel model = new HomeIndexViewModel();
            model.LoadModelData(_unitOfWork);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(IDictionary<string,string> routeValues)
        {
            HomeIndexViewModel model = new HomeIndexViewModel();
            if (ModelState.IsValid)
            {
                model.LoadFilteredModelData(_unitOfWork, routeValues[nameof(model.FilterFrom)], routeValues[nameof(model.FilterTo)]);
                return View(model);
            }
            else
            {
                model.LoadModelData(_unitOfWork);
                return View(model);
            }
        }
        public IActionResult Details(int publisherId)
        {
            HomeDetailsViewModel model = new HomeDetailsViewModel();
            model.LoadModelData(_unitOfWork, publisherId);
            return View(model);
        }

        [HttpPost]
        public IActionResult Details(HomeDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.LoadModelData(_unitOfWork, Convert.ToInt32(model.SelectedId));
                return View(model);
            }
            else
            {
                return View(model);
            }      
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
