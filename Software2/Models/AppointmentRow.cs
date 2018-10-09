using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Models
{
    public class AppointmentRow
    {
        public int Id { get; set; }
        public string Contact { get; set; }
        public string Title { get; set; }
        public string CustomerName { get; set; }
        public DateTime StartDate { get; set; }
        public string Location { get; set; }
    }
}
