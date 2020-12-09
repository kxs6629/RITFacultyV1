using System.Collections.Generic;
using RITFacultyV1.Models;

namespace RITFacultyV1.ViewModels
{
    // View model for the Undergrad service
    public class UndergradViewModel
    {
        public List<UnderGradMajors> UnderGrads { get; set; }
        public string Title { get; set; }
    }
}
