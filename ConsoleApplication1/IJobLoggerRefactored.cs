using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolution
{
    interface IJobLoggerRefactored
    {
        void LogMessage(string message, TypeLog type);
    }
}
