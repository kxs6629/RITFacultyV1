using System.Collections.Generic;
using RITFacultyV1.Models;

namespace RITFacultyV1.ViewModels
{
    public class DegreeViewModel
    {
        public List<UnderGradMajors> UnderGrads { get; set; }
        public List<Grad> Grad { get; set; }
        public string Title { get; set; }
    }
}
