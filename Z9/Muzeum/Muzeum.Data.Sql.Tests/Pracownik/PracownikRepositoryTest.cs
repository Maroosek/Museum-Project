using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Muzeum.Common.Enums;
using Muzeum.Data.Sql.Pracownik;
using Muzeum.IData.Pracownik;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;


namespace Muzeum.Data.Sql.Tests.Pracownik
{
    public class PracownikRepositoryTest
    {
        public IConfiguration Configuration { get; }
        private MuzeumDbContext _context;
        private IPracownikRepository _pracownikRepository;

        public PracownikRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MuzeumDbContext>();
            optionsBuilder.UseMySQL(
                "server=localhost;userid=root;pwd=root;port=3306;database=muzeum_db;");
            _context = new MuzeumDbContext(optionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _pracownikRepository = new PracownikRepository(_context);
        }

        [Fact]
        public async Task StworzPracownik_Returns_Correct_Response()
        {
            var pracownik = new Domain.Pracownik.Pracownik("Imie", "Nazwisko", "PESEL", Plec.Mezczyzna, DateTime.UtcNow, DateTime.UtcNow);

            var pracownikId = await _pracownikRepository.StworzPracownik(pracownik);

            var stworzPracownik = await _context.Pracownik.FirstOrDefaultAsync(x => x.PracownikId == pracownikId);
            Assert.NotNull(stworzPracownik);

            _context.Pracownik.Remove(stworzPracownik);
            await _context.SaveChangesAsync();
        }

    }
}
