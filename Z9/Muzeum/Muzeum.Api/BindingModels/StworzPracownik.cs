using System;
using System.ComponentModel.DataAnnotations;
using Muzeum.Common.Enums;

namespace Muzeum.Api.BindingModels
{
    public class StworzPracownik
    {
        [Required]
        [Display(Name = "Imie Pracownika")]
        public string ImieP { get; set; }

        [Required]
        [Display(Name = "Nazwisko Pracownika")]
        public string NazwiskoP { get; set; }

        [Required]
        [Display(Name = "Pesel Pracownika")]
        public string Pesel { get; set; }

        [Required]
        [Display(Name = "P³eæ")]
        public Plec plec { get; set; }

        [Required]
        [Display(Name = "Data Zatrudnienia")]
        public DateTime DataZatrudnienia { get; set; }

        [Required]
        [Display(Name = "Data Urodzin")]
        public DateTime DataUrodzin { get; set; }
    }
}