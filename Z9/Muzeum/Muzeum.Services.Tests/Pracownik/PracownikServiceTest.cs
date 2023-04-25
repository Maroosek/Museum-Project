using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Muzeum.Common.Enums;
using Muzeum.Domain.DomainExceptions;
using Muzeum.IData.Pracownik;
using Muzeum.IServices.Requests;
using Muzeum.IServices.Pracownik;
using Muzeum.Services.Pracownik;
using Moq;
using Xunit;


namespace Muzeum.Services.Tests.Pracownik
{
    public class PracownikServiceTest
    {
        private readonly IPracownikService _pracownikService;
        private readonly Mock<IPracownikRepository> _pracownikRepositoryMock;

        public PracownikServiceTest()
        {
            //Arrange
            _pracownikRepositoryMock = new Mock<IPracownikRepository>();
            _pracownikService = new PracownikService(_pracownikRepositoryMock.Object);
        }

        [Fact]
        public void StworzPracownik_Returns_throws_InvalidBirthDateException()
        {
            var pracownik = new StworzPracownik
            {
                ImieP = "Email",
                NazwiskoP = "Email",
                Pesel = "Name",
                plec = Plec.Mezczyzna,
                DataUrodzin = DateTime.UtcNow.AddHours(1),
                DataZatrudnienia = DateTime.UtcNow.AddHours(1)
            };

            Assert.ThrowsAsync<InvalidBirthDateException>(() => _pracownikService.StworzPracownik(pracownik));
        }

        [Fact]
        public async Task StworzPracownik_Returns_Correct_Response()
        {
            var pracownik = new StworzPracownik
            {
                ImieP = "Email",
                NazwiskoP = "Email",
                Pesel = "Name",
                plec = Plec.Mezczyzna,
                DataUrodzin = DateTime.UtcNow,
                DataZatrudnienia = DateTime.UtcNow
            };

            int expectedResult = 0;
            _pracownikRepositoryMock.Setup(x => x.StworzPracownik
                (new Domain.Pracownik.Pracownik(
                    pracownik.ImieP,
                    pracownik.NazwiskoP,
                    pracownik.Pesel,
                    pracownik.plec,
                    pracownik.DataUrodzin,
                    pracownik.DataZatrudnienia)))
                .Returns(Task.FromResult(expectedResult));

            //Act
            var result = await _pracownikService.StworzPracownik(pracownik);

            //Assert
            Assert.IsType<Domain.Pracownik.Pracownik>(result);
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.PracownikId);
        }

    }
}
