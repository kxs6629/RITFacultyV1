using System.Collections.Generic;
using RITFacultyV1.Models;

namespace RITFacultyV1.ViewModels
{
    // View model for the Coop service
    public class CoopViewModel
    {
        public List<CoopInformation> coopInformation { get; set; }
        public string Title { get; set; }
    }
}
