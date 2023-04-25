using System.Collections.Generic;

namespace Muzeum.Data.Sql.DAO
{
    public class Eksponat
    {
        public Eksponat()
        {
            Serwisy = new List<Serwis>();
            Wizyty = new List<Wizyta>();
        }

        public int EksponatId { get; set; }
        public string NazwaEksponatu { get; set; }
        public int MagazynId { get; set; }

        public virtual ICollection<Serwis> Serwisy { get; set; }
        public virtual ICollection<Wizyta> Wizyty { get; set; }
        public virtual Magazyn Magazyn { get; set; }

    }
}