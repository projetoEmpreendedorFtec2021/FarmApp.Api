using System;
using System.Collections.Generic;
using System.Text;

namespace FarmApp.Domain.Models.GoogleMaps
{
    public class Result
    {
        public List<AddressComponent> Address_components { get; set; }
        public string Formatted_address { get; set; }
        public IList<Row> Rows { get; set; }
    }
}
