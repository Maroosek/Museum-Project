using System;
using System.Threading.Tasks;
using Muzeum.Api.BindingModels;
using Muzeum.Api.Validation;
using Muzeum.Api.ViewModels;
using Muzeum.Data.Sql;
using Muzeum.Data.Sql.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Muzeum.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class PracownikController : Controller
    {
        private readonly MuzeumDbContext _context;

        public PracownikController(MuzeumDbContext context)
        {
            _context = context ?? throw new ArgumentException((nameof(context)));
        }

        [HttpGet("{pracownikId:min(1)}", Name = "GetPracownikById")]
        public async Task<IActionResult> GetPracownikById(int pracownikId)
        {
            var pracownik = await _context.Pracownik.FirstOrDefaultAsync(x => x.PracownikId == pracownikId);

            if (pracownik != null)
            {
                return Ok(new PracownikViewModel
                {
                    PracownikId = pracownik.PracownikId,
                    ImieP = pracownik.ImieP,
                    NazwiskoP = pracownik.NazwiskoP,
                    Pesel = pracownik.Pesel,
                    plec = pracownik.plec,
                    DataZatrudnienia = pracownik.DataZatrudnienia,
                    DataUrodzin = pracownik.DataUrodzin

                }); ;
            }

            return NotFound();
        }

        [HttpGet("Pesel/{Pesel}", Name = "GetPracownikByPesel")]
        public async Task<IActionResult> GetPracownikByPesel(string pesel)
        {
            var pracownik = await _context.Pracownik.FirstOrDefaultAsync(x => x.Pesel == pesel);

            if (pracownik != null)
            {
                return Ok(new PracownikViewModel
                {
                    PracownikId = pracownik.PracownikId,
                    ImieP = pracownik.ImieP,
                    NazwiskoP = pracownik.NazwiskoP,
                    Pesel = pracownik.Pesel,
                    plec = pracownik.plec,
                    DataZatrudnienia = pracownik.DataZatrudnienia,
                    DataUrodzin = pracownik.DataUrodzin
                });
            }

            return NotFound();
        }

        [ValidateModel]
        //        [Consumes("application/x-www-form-urlencoded")]
        //        [HttpPost("create", Name = "CreateUser")]
        public async Task<IActionResult> Post([FromBody] StworzPracownik StworzPracownik)
        {
            var Pracownik = new Pracownik
            {
                ImieP = StworzPracownik.ImieP,
                NazwiskoP = StworzPracownik.NazwiskoP,
                Pesel = StworzPracownik.Pesel,
                plec = StworzPracownik.plec,
                DataZatrudnienia = StworzPracownik.DataZatrudnienia,
                DataUrodzin = StworzPracownik.DataUrodzin
            };
            await _context.AddAsync(Pracownik);
            await _context.SaveChangesAsync();

            return Created(Pracownik.PracownikId.ToString(), new PracownikViewModel
            {
                PracownikId = Pracownik.PracownikId,
                ImieP = Pracownik.ImieP,
                NazwiskoP = Pracownik.NazwiskoP,
                Pesel = Pracownik.Pesel,
                plec = Pracownik.plec,
                DataZatrudnienia = Pracownik.DataZatrudnienia,
                DataUrodzin = Pracownik.DataUrodzin
            });
        }

        [ValidateModel]
        [HttpPatch("edit/{pracownikId:min(1)}", Name = "EdytujPracownik")]
        //        public async Task<IActionResult> EditUser([FromBody] EditUser editUser,[FromQuery] int userId)
        public async Task<IActionResult> EdytujPracownik([FromBody] EdytujPracownik EdytujPracownik, int pracownikId)
        {
            var pracownik = await _context.Pracownik.FirstOrDefaultAsync(x => x.PracownikId == pracownikId);
            pracownik.ImieP = EdytujPracownik.ImieP;
            pracownik.NazwiskoP = EdytujPracownik.NazwiskoP;
            pracownik.Pesel = EdytujPracownik.Pesel;
            pracownik.plec = EdytujPracownik.plec;
            pracownik.DataZatrudnienia = EdytujPracownik.DataZatrudnienia;
            pracownik.DataUrodzin = EdytujPracownik.DataUrodzin;
            await _context.SaveChangesAsync();
            return NoContent();

            return Ok(new PracownikViewModel
            {
                PracownikId = pracownik.PracownikId,
                ImieP = pracownik.ImieP,
                NazwiskoP = pracownik.NazwiskoP,
                Pesel = pracownik.Pesel,
                plec = pracownik.plec,
                DataZatrudnienia = pracownik.DataZatrudnienia,
                DataUrodzin = pracownik.DataUrodzin
            });
        }

        [ValidateModel]
        [HttpDelete("delete/{pracownikId:min(1)}", Name = "UsunPracownik")]
        public async Task<IActionResult> UsunPracownik(int pracownikId)
        {

            var usunPracownik = await _context.Pracownik.FirstOrDefaultAsync(x => x.PracownikId == pracownikId);
            if (usunPracownik != null)
            {
                _context.Pracownik.Remove(usunPracownik);
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}