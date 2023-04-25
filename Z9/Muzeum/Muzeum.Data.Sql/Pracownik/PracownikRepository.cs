using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Muzeum.IData.Pracownik;
using Microsoft.EntityFrameworkCore;

namespace Muzeum.Data.Sql.Pracownik
{
    public class PracownikRepository : IPracownikRepository
    {
        private readonly MuzeumDbContext _context;

        public PracownikRepository(MuzeumDbContext context)
        {
            _context = context;
        }

        public async Task<int> StworzPracownik(Domain.Pracownik.Pracownik pracownik)
        {
            var pracownikDAO = new DAO.Pracownik
            {
                PracownikId = pracownik.PracownikId,
                ImieP = pracownik.ImieP,
                NazwiskoP = pracownik.NazwiskoP,
                Pesel = pracownik.Pesel,
                plec = pracownik.plec,
                DataZatrudnienia = pracownik.DataZatrudnienia,
                DataUrodzin = pracownik.DataUrodzin
            };

            await _context.AddAsync(pracownikDAO);
            await _context.SaveChangesAsync();

            return pracownikDAO.PracownikId;
        } 

        public async Task<Domain.Pracownik.Pracownik> GetPracownik(int pracownikId)
        {
            var pracownik = await _context.Pracownik.FirstOrDefaultAsync(x => x.PracownikId == pracownikId);
            return new Domain.Pracownik.Pracownik(
                pracownik.PracownikId,
                pracownik.ImieP,
                pracownik.NazwiskoP,
                pracownik.Pesel,
                pracownik.plec, 
                pracownik.DataZatrudnienia,
                pracownik.DataUrodzin
                );

        }

        public async Task<Domain.Pracownik.Pracownik> GetPracownik(string PracownikPesel)
        {
            var pracownik = await _context.Pracownik.FirstOrDefaultAsync(x => x.Pesel == PracownikPesel);
            return new Domain.Pracownik.Pracownik(
                pracownik.PracownikId,
                pracownik.ImieP,
                pracownik.NazwiskoP,
                pracownik.Pesel,
                pracownik.plec,
                pracownik.DataZatrudnienia,
                pracownik.DataUrodzin
                );
        }

        public async Task EdytujPracownik(Domain.Pracownik.Pracownik pracownik)
        {
            var edutujPracownika = await _context.Pracownik.FirstOrDefaultAsync(x => x.PracownikId == pracownik.PracownikId);

            edutujPracownika.ImieP = pracownik.ImieP;
            edutujPracownika.NazwiskoP = pracownik.NazwiskoP;
            edutujPracownika.Pesel = pracownik.Pesel;
            edutujPracownika.plec = pracownik.plec;
            edutujPracownika.DataZatrudnienia = pracownik.DataZatrudnienia;
            edutujPracownika.DataUrodzin = pracownik.DataUrodzin;

            await _context.SaveChangesAsync();
        }
        
        public async Task UsunPracownik(int pracownikId)
        {
            var usunPracownik = await _context.Pracownik.FirstOrDefaultAsync(x=>x.PracownikId == pracownikId);

            if(usunPracownik != null)
            {
                _context.Pracownik.Remove(usunPracownik);
            }

            var UsunSerwis = await _context.Serwis.FirstOrDefaultAsync(x => x.PracownikId == pracownikId);

            if (UsunSerwis != null)
            {
                _context.Serwis.Remove(UsunSerwis);
            }

            await _context.SaveChangesAsync();
        }

    }
}
