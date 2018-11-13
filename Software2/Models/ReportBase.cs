using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Models
{
    public class ReportBase
    {
        public string Title { get; set; }
        public Dictionary<string, string> Properties { get; set; }
    }
}
