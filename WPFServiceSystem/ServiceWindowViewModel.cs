using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace WPFServiceSystem
{
    public class ServiceWindowViewModel:BaseViewModel
    {
        public List<Service> ServiceList { get; set; }
        public Service Service { get; set; }
        public ServiceWindowViewModel(List<Service> item)
        {
            ServiceList = item;
        }
    }
}
