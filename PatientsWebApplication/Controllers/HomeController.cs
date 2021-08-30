using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatientsWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsWebApplication.Controllers
{
    /**
     *  @class HomeController 
     *  @brief This controller has two action. 
     *  @brief HomeController return private policy view and redirect to Patients View
     * */
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        /**
         * @fn new HomeController(logger)
         * @brief class constructor HomeController
         * @param used to log actions
         */
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        /**
       * @fn new Index()
       * @brief action Index used to redirect to Patients view 
       */
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Patients");
        }
        /**
        * @fn new Privacy()
        * @brief action Privacy used to return Privacy view
        */
        public IActionResult Privacy()
        {
            return View();
        }
        /**
         * @fn new Error()
         * @brief action Error used to redirect to Error view. Еhis view is displayed if an error occurs on the server.
         */
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
