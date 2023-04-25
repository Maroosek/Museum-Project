using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Muzeum.IServices.Requests;

namespace Muzeum.IServices.Pracownik
{
    public interface IPracownikService
    {
        Task<Muzeum.Domain.Pracownik.Pracownik> GetPracownikByPracownikId (int pracownikId);
        Task<Muzeum.Domain.Pracownik.Pracownik> GetPracownikByPesel(string PracownikPesel);
        Task<Muzeum.Domain.Pracownik.Pracownik> StworzPracownik(StworzPracownik stworzPracownik);
        Task EdytujPracownik(EdytujPracownik stworzPracownik, int pracownikId);
        Task UsunPracownik(int pracownikId);
    }
}
