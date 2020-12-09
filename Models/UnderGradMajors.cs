using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RITFacultyV1.Models
{
    // Represents the undergraduate majors as presented by the API
    public class UnderGradMajors
    {
        public string degreeName { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        // Collection of concentration Strings
        public List<string> concentrations { get; set; }
    }
}
