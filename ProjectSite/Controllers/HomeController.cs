using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectSite.Data;
using ProjectSite.Models;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Collections;

namespace ProjectSite.Controllers
{
	public class HomeController : Controller
	{

        private readonly ProjectSiteContext _context;
        public HomeController(ProjectSiteContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
		{
            return _context.Restaurant != null ?
                          View(await _context.Restaurant.ToListAsync()) :
                          Problem("Entity set 'ProjectSiteContext.Restaurant'  is null.");
		}

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Review == null)
            {
                return NotFound();
            }

            ViewData["RestName"] = _context.Restaurant.Single(b => b.id == (int)id).res_name;
            var context = await _context.Review.Where(b => b.id_restaurant == id).ToListAsync();

            if (context.Any())
            {

                double service_assessment = (double)context.Average(u => u.service_assessment);
                double evaluation_of_the_first_courses = (double)context.Average(u => u.evaluation_of_the_first_courses);
                double evaluation_of_the_second_courses = (double)context.Average(u => u.evaluation_of_the_second_courses);
                double evaluation_of_snacks = (double)context.Average(u => u.evaluation_of_snacks);
                double dessert_evaluation = (double)context.Average(u => u.dessert_evaluation);
                double assessment_of_the_atmosphere = (double)context.Average(u => u.assessment_of_the_atmosphere);

                ViewData["service_assessment"] = Math.Round(service_assessment, 1);
                ViewData["evaluation_of_the_first_courses"] = Math.Round(evaluation_of_the_first_courses, 1);
                ViewData["evaluation_of_the_second_courses"] = Math.Round(evaluation_of_the_second_courses, 1);
                ViewData["evaluation_of_snacks"] = Math.Round(evaluation_of_snacks, 1);
                ViewData["dessert_evaluation"] = Math.Round(dessert_evaluation, 1);
                ViewData["assessment_of_the_atmosphere"] = Math.Round(assessment_of_the_atmosphere, 1);
                ViewData["table_checker"] = null;
            }
            else
            {
                ViewData["service_assessment"] = 0;
                ViewData["evaluation_of_the_first_courses"] = 0;
                ViewData["evaluation_of_the_second_courses"] = 0;
                ViewData["evaluation_of_snacks"] = 0;
                ViewData["dessert_evaluation"] = 0;
                ViewData["assessment_of_the_atmosphere"] = 0;
                ViewData["table_checker"] = "Тут пока нет отзывов";
            }

            return _context.Review != null ?
                          View(context) :
                          Problem("Entity set 'ProjectSiteContext.Review'  is null.");
        }
        public IActionResult Rest(string restid)
		{
            ViewData["Message"] = restid;
			return View();
		}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
		private bool RestaurantExists(int id)
        {
          return (_context.Restaurant?.Any(e => e.id == id)).GetValueOrDefault();
        }
	}
}
