using System.Collections.Generic;
using RITFacultyV1.Models;

namespace RITFacultyV1.ViewModels
{
    // View model for the Employee service
    public class EmployeeViewModel
    {
        public List<ProfessionalEmploymentInformation> employeeInformation { get; set; }
        public string Title { get; set; }
    }
}
