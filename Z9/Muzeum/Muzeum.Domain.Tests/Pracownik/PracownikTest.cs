using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Muzeum.Common.Enums;
using Muzeum.Domain.DomainExceptions;
using Xunit;


namespace Muzeum.Domain.Tests.Pracownik
{
    public class PracownikTest
    {
        public PracownikTest()
        {
            //Arrange
            //Act
            //Assert
        }

        [Fact]
        public void StworzPracownik_Returns_throws_InvalidBirthDateException()
        {
            Assert.Throws<InvalidBirthDateException>
            (() => new Domain.Pracownik.Pracownik(
                "Imie",
                "Nazwisko",
                "PESEL",
                Plec.Mezczyzna,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1)));
        }

        [Fact]
        public void StworzPracownik_Returns_Correct_Response()
        {
            var pracownik = new Domain.Pracownik.Pracownik("Imie", "Nazwisko", "PESEL", Plec.Mezczyzna, DateTime.UtcNow, DateTime.UtcNow);

            Assert.Equal("Imie", pracownik.ImieP);
            Assert.Equal("Nazwisko", pracownik.NazwiskoP);
            Assert.Equal("PESEL", pracownik.Pesel);
            Assert.Equal(Plec.Mezczyzna, pracownik.plec);


        }

    }
}
