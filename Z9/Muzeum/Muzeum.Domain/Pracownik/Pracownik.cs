using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Muzeum.Common.Enums;
using Muzeum.Domain.DomainExceptions;

namespace Muzeum.Domain.Pracownik
{
    public class Pracownik
    {
        public int PracownikId { get; set; }
        public string ImieP { get; set; }
        public string NazwiskoP { get; set; }
        public string Pesel { get; set; }
        public Plec plec { get; set; }
        public DateTime DataZatrudnienia { get; set; }
        public DateTime DataUrodzin { get; set; }

        public Pracownik (int id, string Imie, string Nazwisko, string pesel, Plec Plec, DateTime Zatrudnienie, DateTime Urodziny) 
        {
            PracownikId = id;
            ImieP = Imie;
            NazwiskoP = Nazwisko;
            Pesel = pesel;
            this.plec = Plec;
            DataZatrudnienia = Zatrudnienie;
            DataUrodzin = Urodziny;
        }

        public Pracownik(string Imie, string Nazwisko, string pesel, Plec plec, DateTime dataZatrudnienia, DateTime Urodziny)
        {
            if (Urodziny >= DateTime.UtcNow)
                throw new InvalidBirthDateException(Urodziny);
            ImieP = Imie;
            NazwiskoP = Nazwisko;
            Pesel = pesel;
            this.plec = plec;
            DataZatrudnienia = dataZatrudnienia;
            DataUrodzin = Urodziny;
        }

        public void EdytujPracownik( string Imie, string Nazwisko, string pesel, Plec plec, DateTime Zatrudnienie, DateTime Urodziny)
        {
            if (Urodziny >= DateTime.UtcNow)
                throw new InvalidBirthDateException(Urodziny);
            ImieP = Imie;
            NazwiskoP = Nazwisko;
            Pesel = pesel;
            this.plec = plec;
            DataZatrudnienia = Zatrudnienie;
            DataUrodzin = Urodziny;
        }

    }
}
