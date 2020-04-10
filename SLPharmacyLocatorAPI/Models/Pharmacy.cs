using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLPharmacyLocatorAPI.Models
{
    public class Pharmacy
    {
        public int Id { get; set; }
        public string District { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string WhatsApp { get; set; }
        public string Viber { get; set; }
        public string MoH { get; set; }
        public string Email { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
