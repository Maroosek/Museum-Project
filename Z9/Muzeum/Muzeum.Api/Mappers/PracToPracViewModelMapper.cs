using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Muzeum.Api.ViewModels;


namespace Muzeum.Api.Mappers
{
    public class PracToPracViewModelMapper
    {
        public static PracownikViewModel PracToPracViewModel(Domain.Pracownik.Pracownik pracownik)
        {
            var pracownikViewModel = new PracownikViewModel
            {
                PracownikId = pracownik.PracownikId,
                ImieP = pracownik.ImieP,
                NazwiskoP = pracownik.NazwiskoP,
                Pesel = pracownik.Pesel,
                plec = pracownik.plec,
                DataZatrudnienia = pracownik.DataZatrudnienia,
                DataUrodzin = pracownik.DataUrodzin
            };
            return pracownikViewModel;
        }
    }
}
