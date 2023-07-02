using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Input;

namespace WPFServiceSystem
{
    public class ServicesDTO:BaseViewModel
    {
        public int ServiceID { get; set; }
        public int BranchID { get; set; }
        public string ServiceName { get; set; }
        public string BranchName { get; set; }
    }
}