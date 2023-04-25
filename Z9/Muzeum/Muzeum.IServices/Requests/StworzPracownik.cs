using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Muzeum.Common.Enums;

namespace Muzeum.IServices.Requests
{
    public class StworzPracownik
    {
        public string ImieP { get; set; }
        public string NazwiskoP { get; set; }
        public string Pesel { get; set; }
        public Plec plec { get; set; }
        public DateTime DataZatrudnienia { get; set; }
        public DateTime DataUrodzin { get; set; }
    }
}
