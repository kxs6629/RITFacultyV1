using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RITFacultyV1.Models
{
    //Model that represents the employee data from the API
    public class Employee
    {
        public EmploymentTable employmentTable { get; set; }
    }
    // Represents individual employment information as presented in the API
    public class ProfessionalEmploymentInformation
    {
        public string employer { get; set; }
        public string degree { get; set; }
        public string city { get; set; }
        public string title { get; set; }
        public string startDate { get; set; }
    }

    // Represents the collection of individual employment information
    public class EmploymentTable
    {
        public string title { get; set; }
        public List<ProfessionalEmploymentInformation> professionalEmploymentInformation { get; set; }
    }
}
