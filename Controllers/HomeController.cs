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
            var getAbout = new GetAbout();
            var about = await getAbout.GetAboutInfo();
            var homeViewModel = new HomeViewModel()
            {
                About = about,
                Title = "About Us"
            };
            return View(homeViewModel);
        }

        /*
         * Combined the Undergrad and Graduate calls to the API to display all
         * information onto one page
         */
        public async Task<IActionResult> Degree() 
        {
            var getUnder = new GetUnderGraduate();
            var under = await getUnder.GetAllUnderGrads();
            var getGrad = new GetGraduate();
            var grad = await getGrad.GetAllGrads();
            var degreeViewModel = new DegreeViewModel()
            {
                UnderGrads = under.ToList(),
                Grad = grad.ToList(),
                Title = "A Look At Our Programs"
            };
            return View(degreeViewModel);
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
                Title = "Recent Co-op Information"
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
                Title = "Recent Employment Information"
            };
            return View(empViewModel);
            
        }

        /**
         * Reponsible for creating Faculty page when loaded in
         * This data includes information on the faculty data provided by the API
         */
        public async Task<IActionResult> Faculty()
        {
            // Create service object
            var getallFaculty = new GetFaculty();
            // Call method from service object that returns List of faculty, wait for reponse to move on
            var allFaculty = await getallFaculty.GetAllFaculty();
            // Sorts List from last call
            var sortedFaculty = allFaculty.OrderBy(f => f.username);
            // Create view model using the given list and title
            var facultyViewModel = new FacultyViewModel()
            {
                Faculty = sortedFaculty.ToList(),
                Title = "This is Our Faculty"
            };
            // returns created view, this process is similar for the functions below
            return View(facultyViewModel);
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
                Title = "This is Our Staff"
            };
            return View(staffViewModel);
        }

    }
}
