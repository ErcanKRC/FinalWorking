using FinalWorking.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWorking.Models
{
    public class MonitorModel : TableData
    {
        public string MonitorName { get; set; }
        public int MonitorPrice { get; set; }
    }
}
