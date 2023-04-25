using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzeum.IData.Pracownik
{
    public interface IPracownikRepository
    {
        Task<int> StworzPracownik(Muzeum.Domain.Pracownik.Pracownik pracownik);
        Task<Muzeum.Domain.Pracownik.Pracownik> GetPracownik(int pracownikId);
        Task<Muzeum.Domain.Pracownik.Pracownik> GetPracownik(string PracownikPesel);
        Task EdytujPracownik(Domain.Pracownik.Pracownik pracownik);
        Task UsunPracownik(int pracownikId);
    }
}
