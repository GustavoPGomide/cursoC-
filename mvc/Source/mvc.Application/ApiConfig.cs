using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace mvc.Application
{
   public class ApiConfig
    {
        public static string EnderecoApi { get; set; } = "http://localhost:49871/api";
    }
}
