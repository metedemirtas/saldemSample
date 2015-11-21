using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCodeFirst.Models
{
    public class Afet
    {
        public int  Id { get; set; }
        public string SeriNo { get; set; }
        public DateTime BaslangicTarih { get; set; }
        public DateTime BitisTarih { get; set; }
        public virtual AfetTur AfetTuru { get; set; }

        public virtual Sehir Sehir { get; set; }
        public virtual Ilce Ilce { get; set; }

        public String Neden { get; set; }
        public String Enlem { get; set; }
        public String Boylam { get; set; }
        public String Aciklama { get; set; }
        public String EtkiledigiAlanlar { get; set; }
        public String Kaynak { get; set; }

        public  List<AfetResim> AfetResim { get; set; }


    }
}