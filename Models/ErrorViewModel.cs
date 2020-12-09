using System;

namespace RITFacultyV1.Models
{
    // Used to represent an error should it occur in the MVC
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}