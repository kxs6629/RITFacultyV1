using System.Collections.Generic;
using RITFacultyV1.Models;

namespace RITFacultyV1.ViewModels
{
    // View model for the Staff service
    public class StaffViewModel
    {
        public List<Staff> Staff{ get; set; }
        public string Title { get; set; }
    }
}
