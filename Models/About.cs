using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RITFacultyV1.Models
{
    /**
     * Model that represents the About data from the API
     */
    public class About
    {
        public string title { get; set; }
        public string description { get; set; }
        public string quote { get; set; }
        public string quoteAuthor { get; set; }
    }
}
