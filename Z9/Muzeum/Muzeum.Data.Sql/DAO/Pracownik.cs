using System;
using System.Collections.Generic;
using Muzeum.Common.Enums;

namespace Muzeum.Data.Sql.DAO
{
    public class Pracownik
    {
        public Pracownik()
        {
            Serwisy = new List<Serwis>();
        }

        public int PracownikId { get; set; }
        public string ImieP { get; set; }
        public string NazwiskoP { get; set; }
        public string Pesel { get; set; }
        public Plec plec { get; set; }
        public DateTime DataZatrudnienia { get; set; }
        public DateTime DataUrodzin { get; set; }


        public virtual ICollection<Serwis> Serwisy { get; set; }

    }
}