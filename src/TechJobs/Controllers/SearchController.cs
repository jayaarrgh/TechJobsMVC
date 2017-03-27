using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;
            if (searchType != "all")
            {
                List<Dictionary<string, string>> jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.jobs = jobs;
                ViewBag.title = "Results for '" + searchTerm + "' in " +searchType;
                return View("Index", jobs);
            }
            else
            {
                List<Dictionary<string, string>> jobs = JobData.FindByValue(searchTerm);
                ViewBag.jobs = jobs;
                ViewBag.title = "Results for '" + searchTerm + "' in All jobs";
                return View("Index", jobs);
            }
            
        }

    }
}
