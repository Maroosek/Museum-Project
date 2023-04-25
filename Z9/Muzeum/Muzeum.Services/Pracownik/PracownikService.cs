using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Muzeum.IData.Pracownik;
using Muzeum.IServices.Requests;
using Muzeum.IServices.Pracownik;

namespace Muzeum.Services.Pracownik
{
    public class PracownikService : IPracownikService
    {
        private readonly IPracownikRepository _pracownikRepository;

        public PracownikService(IPracownikRepository pracownikRepository) 
        {
            _pracownikRepository = pracownikRepository ?? throw new ArgumentException((nameof(pracownikRepository)));
        }

        public Task<Domain.Pracownik.Pracownik> GetPracownikByPracownikId(int pracownikId)
        {
            return _pracownikRepository.GetPracownik(pracownikId);
        }

        public Task<Domain.Pracownik.Pracownik> GetPracownikByPesel(string PracownikPesel) 
        {
            return _pracownikRepository.GetPracownik(PracownikPesel);
        }

        public async Task<Domain.Pracownik.Pracownik> StworzPracownik(StworzPracownik stworzPracownik) 
        {
            var pracownik = new Domain.Pracownik.Pracownik(
                stworzPracownik.ImieP, 
                stworzPracownik.NazwiskoP, 
                stworzPracownik.Pesel, 
                stworzPracownik.plec, 
                stworzPracownik.DataZatrudnienia, 
                stworzPracownik.DataUrodzin
                );

            var pracownikId = await _pracownikRepository.StworzPracownik(pracownik);

            pracownik.PracownikId = pracownikId;

            return pracownik;
        }

        public async Task EdytujPracownik (EdytujPracownik stworzPracownik, int pracownikId)  //Task<Domain.Pracownik.Pracownik> EdytujPracownik(EdytujPracownik edytujPracownik)
        {
            var pracownik = await _pracownikRepository.GetPracownik(pracownikId);

            pracownik.EdytujPracownik(
                stworzPracownik.ImieP, 
                stworzPracownik.NazwiskoP,
                stworzPracownik.Pesel, 
                stworzPracownik.plec, 
                stworzPracownik.DataZatrudnienia, 
                stworzPracownik.DataUrodzin
                );

            await _pracownikRepository.EdytujPracownik(pracownik);
        }

        public async Task UsunPracownik(int pracownikId)
        {
            await _pracownikRepository.UsunPracownik(pracownikId);
        }

    }
}
