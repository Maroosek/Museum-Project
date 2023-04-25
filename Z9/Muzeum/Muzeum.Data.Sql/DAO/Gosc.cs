using System;
using System.Collections.Generic;

namespace Muzeum.Data.Sql.DAO
{
    public class Gosc
    {
        public Gosc()
        {
            Wizyty = new List<Wizyta>();
        }

        public int GoscId {get; set;}
        public int OdwiedzajacyId {get; set;}
        public DateTime DataOdwiedzin { get; set; }

        public virtual ICollection<Wizyta> Wizyty { get; set; }

    }
}