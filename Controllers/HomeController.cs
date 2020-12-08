using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RITFacultyV1.Models;
using RITFacultyV1.ViewModels;
using RITFacultyV1.Services;

namespace RITFacultyV1.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var getallFaculty = new GetFaculty();
            var allFaculty = await getallFaculty.GetAllFaculty();
            var sortedFaculty = allFaculty.OrderBy(f => f.username);
            var homeViewModel = new HomeViewModel()
            {
                Faculty = sortedFaculty.ToList(),
                Title = "This is your Faculty"
            };
            return View(homeViewModel);
        }

        public async Task<IActionResult> Under()
        {
            var getUnder = new GetUnderGraduate();
            var under = await getUnder.GetAllUnderGrads();
            var underViewModel = new UndergradViewModel()
            {
                UnderGrads = under.ToList(),
                Title = "Undergraduate Programs"
            };
            return View(underViewModel);
        }

    }
}
