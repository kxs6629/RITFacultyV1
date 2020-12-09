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
        /*
         * Responsible for creating the Index page when loaded in
         * This data includes information on faculty that is provided by the API
         */
        public async Task<IActionResult> Index()
        {
            // Create service object
            var getallFaculty = new GetFaculty();
            // Call method from service object that returns List of faculty, wait for reponse to move on
            var allFaculty = await getallFaculty.GetAllFaculty();
            // Sorts List from last call
            var sortedFaculty = allFaculty.OrderBy(f => f.username);
            // Create view model using the given list and title
            var homeViewModel = new HomeViewModel()
            {
                Faculty = sortedFaculty.ToList(),
                Title = "This is your Faculty"
            };
            // returns created view, this process is similar for the functions below
            return View(homeViewModel);
        }

        /*
         * Responsible for creating the Under page when loaded in
         * This data includes information on undergraduate degrees that is provided by the API
         */
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

        /*
         * Responsible for creating the Grad page when loaded in
         * This data includes information on graduate degrees that is provided by the API
         */
        public async Task<IActionResult> Grad()
        {
            var getGrad = new GetGraduate();
            var grad = await getGrad.GetAllGrads();
            var gradViewModel = new GradViewModel()
            {
                Grad = grad.ToList(),
                Title = "Graduate Programs"
            };
            return View(gradViewModel);
        }

        /*
         * Responsible for creating the Index page when loaded in
         * This data includes information from the about section provided by the API
         */
        public async Task<IActionResult> About()
        {
            var getAbout = new GetAbout();
            var about = await getAbout.GetAboutInfo();
            var aboutViewModel = new AboutViewModel()
            {
                About = about,
                Title = "About Us"
            };
            return View(aboutViewModel);
        }

        /*
         * Responsible for creating the Coop page when loaded in
         * This data includes information on coop data that is provided by the API
         */
        public async Task<IActionResult> Coop()
        {
            var getCoop = new GetCoop();
            var coop = await getCoop.getAllCoops();
            var coopViewModel = new CoopViewModel()
            {
                coopInformation = coop,
                Title = "Co-op Information"
            };
            return View(coopViewModel);
  
        }

        /*
         * Responsible for creating the Employee page when loaded in
         * This data includes information on employment data that is provided by the API
         */
        public async Task<IActionResult> Employee()
        {
            var getEmp = new GetEmployee();
            var emp = await getEmp.getAllEmps();
            var empViewModel = new EmployeeViewModel()
            {
                employeeInformation = emp,
                Title = "Employment Information"
            };
            return View(empViewModel);
            
        }

        /*
        * Responsible for creating the Staff page when loaded in
        * This data includes information on staff data that is provided by the API
        */
        public async Task<IActionResult> Staff() 
        {
            var getStaff = new GetStaff();
            var staff = await getStaff.getAllStaff();
            var sortedStaff = staff.OrderBy(f => f.username);
            var staffViewModel = new StaffViewModel()

            {
                Staff = sortedStaff.ToList(),
                Title = "This is your Faculty"
            };
            return View(staffViewModel);
        }

    }
}
