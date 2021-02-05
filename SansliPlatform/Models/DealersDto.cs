using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SansliPlatform.Models
{
    public class DealersDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int DealerCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int DeviceId { get; set; }
    }
}
