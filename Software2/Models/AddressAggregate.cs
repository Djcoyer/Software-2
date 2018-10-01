using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Models
{
    public class AddressAggregate
    {
        public int AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Phone { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string PostalCode { get; set; }
    }
}
