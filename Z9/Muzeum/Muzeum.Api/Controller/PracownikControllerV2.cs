using System;
using System.Threading.Tasks;
using Muzeum.Api.BindingModels;
using Muzeum.Api.Validation;
using Muzeum.Api.ViewModels;
using Muzeum.Data.Sql.DAO;
using Muzeum.Data.Sql;
using Muzeum.Api.Mappers;
using Muzeum.IServices.Pracownik;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Muzeum.Api.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/Pracownik")]

    public class PracownikControllerV2 : Controller
    {
        private readonly MuzeumDbContext _context;
        private readonly IPracownikService _pracownikService;

        public PracownikControllerV2(MuzeumDbContext context, IPracownikService pracownikService)
        {
            _context = context;
            _pracownikService = pracownikService;
        }

        [HttpGet(template: "GetAllPracownik")]
        public List<Pracownik> GetAllPracownik()
        {
            return _context.Pracownik.ToList();
        }

        [HttpGet("{pracownikId:min(1)}", Name = "GetPracownikById")]
        public async Task<IActionResult> GetPracownikById(int pracownikId)
        {
            var pracownik = await _pracownikService.GetPracownikByPracownikId(pracownikId);

            if (pracownik != null)
            {
                return Ok(PracToPracViewModelMapper.PracToPracViewModel(pracownik));
            }

            return NotFound();
        }

        [HttpGet("Pesel/{Pesel}", Name = "GetPracownikByPesel")]
        public async Task<IActionResult> GetPracownikByPesel(string Pesel)
        {
            var pracownik = await _pracownikService.GetPracownikByPesel(Pesel);

            if (pracownik.Pesel != null)
            {
                return Ok(PracToPracViewModelMapper.PracToPracViewModel(pracownik));
            }

            return NotFound();
        }

        [ValidateModel]
        public async Task<IActionResult> Post([FromBody] IServices.Requests.StworzPracownik stworzPracownik)
        {
            var pracownik = await _pracownikService.StworzPracownik(stworzPracownik);
            return Created(pracownik.PracownikId.ToString(), PracToPracViewModelMapper.PracToPracViewModel(pracownik));
        }

        [ValidateModel]
        [HttpPatch("edit/{pracownikId:min(1)}", Name = "EdytujPracownik")]
        public async Task<IActionResult> EdytujPracownik([FromBody] IServices.Requests.EdytujPracownik edytujPracownik, int pracownikId)
        {
            await _pracownikService.EdytujPracownik(edytujPracownik, pracownikId);
            return NoContent();
        }

        [ValidateModel]
        [HttpDelete("delete/{pracownikId:min(1)}", Name = "UsunPracownik")]
        public async Task<IActionResult>UsunPracownik(int pracownikId)
        {
            await _pracownikService.UsunPracownik(pracownikId);
            return NoContent();
        }

    }
}