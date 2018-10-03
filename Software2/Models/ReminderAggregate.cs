using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Models
{
    public class ReminderAggregate
    {
        public int IncrementId { get; set; }
        public int ReminderId { get; set; }
        public int IncrementValue { get; set; }
        public string IncrementDescription { get; set; }
        public int AppointmentId { get; set; }
        public DateTime ReminderDate { get; set; }
        public string ReminderCol { get; set; }
    }
}
