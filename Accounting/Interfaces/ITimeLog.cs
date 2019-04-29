using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Interfaces
{
    public interface ITimeLog
    {
        DateTime DateTime { get; set; }
        int Hours { get; set; }
    }
}
