using System;

namespace LifeCareFullMVC.Models
{
    public class ErrorViewModel
    {
        // if any error occured this will show the error
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
