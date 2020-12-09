using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RITFacultyV1.Models
{
    
    //Model that represents the Coop data from the API
    public class Coop
    {
        public CoopTable coopTable { get; set; }
    }

    //Model that represents a specific coop object 
    public class CoopInformation
    {
        public string employer { get; set; }
        public string degree { get; set; }
        public string city { get; set; }
        public string term { get; set; }
    }

    //Represents the collection of individual coop information
    public class CoopTable
    {
        public string title { get; set; }
        public List<CoopInformation> coopInformation { get; set; }
    }
}
