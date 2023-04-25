using System;
using System.Collections.Generic;

namespace Muzeum.Data.Sql.DAO
{
    public class Magazyn
    {
        public Magazyn()
        {
            Eksponaty = new List<Eksponat>();
        }

        public string NazwaEksponatu { get; set; }
        public DateTime DataOtrzymania { get; set; }
        public int EksponatId { get; set; }
        public int MagazynId { get; set; }

        public virtual ICollection<Eksponat> Eksponaty { get; set; }

    }
}