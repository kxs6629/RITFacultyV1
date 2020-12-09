using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RITFacultyV1.Models
{
    // Represents graduate objects as given by the API
    public class Grad
    {
        public string degreeName { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<string> concentrations { get; set; }
        public List<string> availableCertificates { get; set; }
    }
}
