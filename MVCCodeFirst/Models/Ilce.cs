using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCCodeFirst.Models
{
    public class Ilce
    {
        public int Id { get; set; }
        public virtual Sehir Sehir { get; set; }
        public String Name { get; set; }
    }
}
