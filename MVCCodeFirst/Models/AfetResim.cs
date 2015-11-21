using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCCodeFirst.Models
{
    public class AfetResim
    {
        public int Id { get; set; }
        public Byte[] Data { get; set; }
        public virtual Afet Afet { get; set; }

    }
}
