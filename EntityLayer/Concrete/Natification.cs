using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Natification
    {
        public int NatificationId { get; set; }
        public string Natificationtype { get; set; }
        public string NatificationTypeSyble { get; set; }
        public string NatificationColor { get; set; }
        public string NatificationDetails { get; set; }
        public DateTime NatificationDate { get; set; }
        public bool NatificationStatus { get; set; }
    }
}
