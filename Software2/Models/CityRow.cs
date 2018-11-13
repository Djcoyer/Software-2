using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Models
{
    class CityRow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
