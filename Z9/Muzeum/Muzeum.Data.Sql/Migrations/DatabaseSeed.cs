using System;
using System.Collections.Generic;
using System.Linq;
using Muzeum.Common.Enums;
//using Muzeum.Common.Extensions;
using Muzeum.Data.Sql.DAO;

namespace Muzeum.Data.Sql.Migrations
{
    public class DatabaseSeed
    {
        private readonly MuzeumDbContext _context;

        public DatabaseSeed(MuzeumDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            #region UtworzPracownikow
            var ListaPracownikow = BuildListaPracownikow();
            _context.Pracownik.AddRange(ListaPracownikow);
            _context.SaveChanges();
            #endregion

            #region UtworzGosci
            var ListaGosci = BuildListaGosci();
            _context.Gosc.AddRange(ListaGosci);
            _context.SaveChanges();
            #endregion

            #region UtworzMagazyny
            var ListaMagazynow = BuildListaMagazynow();
            _context.Magazyn.AddRange(ListaMagazynow);
            _context.SaveChanges();
            #endregion

            #region UtworzEksponaty
            var ListaEksponatow = BuildListaEksponatow(ListaMagazynow); 
            _context.Eksponat.AddRange(ListaEksponatow);
            _context.SaveChanges();
            #endregion

            #region UtworzSerwisy
            var ListaSerwisow = BuildListaSerwisow(ListaPracownikow, ListaEksponatow);
            _context.Serwis.AddRange(ListaSerwisow);
            _context.SaveChanges();
            #endregion

            #region UtworzWizyty
            var ListaWizyt = BuildListaWizyt(ListaGosci, ListaEksponatow); 
            _context.Wizyta.AddRange(ListaWizyt);
            _context.SaveChanges();
            #endregion

        }

        private IEnumerable<DAO.Pracownik> BuildListaPracownikow()
        {
            var ListaPracownikow = new List<DAO.Pracownik>();
            var Pracownik = new DAO.Pracownik()
            {
                ImieP = "Marek",
                NazwiskoP = "Korkosz",
                Pesel = "12345678901",
                plec = Plec.Mezczyzna,
                DataZatrudnienia = DateTime.Now.AddYears(-3),
                DataUrodzin = new DateTime(2000, 07, 17)
            };
            ListaPracownikow.Add(Pracownik);

            var Pracownik2 = new DAO.Pracownik()
            {
                ImieP = "Marian",
                NazwiskoP = "Hermaszerfski",
                Pesel = "12345678902",
                plec = Plec.Mezczyzna,
                DataZatrudnienia = DateTime.Now.AddYears(-3),
                DataUrodzin = new DateTime(2000, 05, 12)
            };
            ListaPracownikow.Add(Pracownik2);

            for (int i = 3; i <= 20; i++)
            {
                var Pracownik3 = new DAO.Pracownik
                {
                    ImieP = "Imie" + i,
                    NazwiskoP = "Nazwisko" + i,
                    Pesel = "1234567890" + i,
                    plec = i % 2 == 0 ? Plec.Mezczyzna : Plec.Kobieta,
                    DataZatrudnienia = DateTime.Now.AddYears(-2),
                    DataUrodzin = new DateTime(1994, 6, 7)
                };
                ListaPracownikow.Add(Pracownik3);
            }

            return ListaPracownikow;
        }
        private IEnumerable<Gosc> BuildListaGosci()
        {
            var ListaGosci = new List<Gosc>();
                var gosc = new Gosc()
                {
                    OdwiedzajacyId = 1,
                    DataOdwiedzin = DateTime.Now
                };

                ListaGosci.Add(gosc);

            return ListaGosci;
        }
        private IEnumerable<Magazyn> BuildListaMagazynow()
        {
            var ListaMagazynow = new List<Magazyn>();
                var magazyn = new Magazyn()
                {
                    DataOtrzymania = DateTime.Now,
                    NazwaEksponatu = "Nintendo Entertainment System - NES",
                    EksponatId = 1
                };

                ListaMagazynow.Add(magazyn);

            return ListaMagazynow;
        }
        private IEnumerable<Eksponat> BuildListaEksponatow(IEnumerable<Magazyn> ListaMagazynow)
        {
            var ListaEksponatow = new List<Eksponat>();
            var Eksponat = new Eksponat()
            {
                NazwaEksponatu = "Nintendo Entertainment System - NES",
                MagazynId = 1,
                EksponatId = 1
            };

            ListaEksponatow.Add(Eksponat);
            

            /*foreach (var Magazyn in ListaMagazynow)
            {
                var magazyn = ListaMagazynow.First(x => x.EksponatId == Eksponat.EksponatId); 
            }*/

            return ListaEksponatow;
        }
        private IEnumerable<Serwis> BuildListaSerwisow(IEnumerable<DAO.Pracownik> pracowniks, IEnumerable<Eksponat> ListaEksponatow)
        {
            var ListaSerwisow = new List<Serwis>();
            var Serwis = new Serwis()
            {
                SerwisId = 1,
                NazwaEksponatu = "Nintendo Entertainment System - NES",
                EksponatId = 1,
                MagazynId = 1,
                PracownikId = 10,
                DataOtrzymania = DateTime.Now.AddYears(-1),
                DataZwrotu = DateTime.Now
            };

            ListaSerwisow.Add(Serwis);

            /*foreach (var Eksponat in ListaEksponatow)
            {
                var eksponat = ListaEksponatow.First(x => x.EksponatId == Serwis.EksponatId);
                
            }*/

            return ListaSerwisow;
        }
        private IEnumerable<Wizyta> BuildListaWizyt(IEnumerable<Gosc> ListaGosci, IEnumerable<Eksponat> ListaEksponatow)
        {
            var ListaWizyt = new List<Wizyta>();
            var Wizyta = new Wizyta
            {
                OdwiedzajacyId = 1,
                EksponatId = 1,
                DataOdwiedzin = DateTime.Now
            };

            ListaWizyt.Add(Wizyta);

            /*foreach (var Gosc in ListaGosci)
            {
                var gosc = ListaGosci.First(x => x.OdwiedzajacyId == Wizyta.OdwiedzajacyId);

            }*/

            return ListaWizyt;
        }
    }
}
