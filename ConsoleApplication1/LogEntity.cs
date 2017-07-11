using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolution
{
    public class LogEntity
    {

        public string Message { get; set; }
        public bool LogMessage { get; set; }
        public bool LogWarning { get; set; }
        public bool LogError { get; set; }
    }
}
