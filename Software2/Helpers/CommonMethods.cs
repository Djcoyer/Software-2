using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Helpers
{
    public static class CommonMethods
    {
        public static T AdjustTimeZone<T>(T item) where T: appointment
        {

            return item;
        }

        public static IEnumerable<T> AdjustTimeZone<T>(IEnumerable<T> items) where T: appointment
        {
            foreach(var item in items)
            {
                item.start = TimeZoneInfo.ConvertTime(item.start, TimeZoneInfo.Local);
                item.end = TimeZoneInfo.ConvertTime(item.end, TimeZoneInfo.Local);
            }

            return items;
        }
    }
}
