using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Models
{
    public class ReminderAggregate
    {
        public int ReminderId { get; set; }
        public int AppointmentId { get; set; }
        public int IncrementId { get; set; }
        public int IncrementValue { get; set; }
        public string IncrementDescription { get; set; }
        public string CustomerName { get; set; }
        public string Location { get; set; }
        public DateTime ReminderDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ReminderCol { get; set; }
    }
}
