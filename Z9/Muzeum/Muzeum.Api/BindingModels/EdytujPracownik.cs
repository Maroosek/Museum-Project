using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Muzeum.Common.Enums;

namespace Muzeum.Api.BindingModels
{
    public class EdytujPracownik
    {
        //        [Required]
        [Display(Name = "Imie Pracownika")]
        public string ImieP { get; set; }
        //        [Required]
        //        [EmailAddress]
        //        [DataType(DataType.EmailAddress)]
        [Display(Name = "Nazwisko Pracownika")]
        public string NazwiskoP { get; set; }

        //        [Required]
        [Display(Name = "Pesel Pracownika")]
        public string Pesel { get; set; }

        //        [Required]
        [Display(Name = "P³eæ")]
        public Plec plec { get; set; }

        [Display(Name = "Data Urodzin")]
        public DateTime DataZatrudnienia { get; set; }

        [Display(Name = "Data Urodzin")]
        public DateTime DataUrodzin { get; set; }
    }
    
    /*public class EdytujPracownikValidator : AbstractValidator<EdytujPracownik> {
            public EdytujPracownikValidator() {
                    RuleFor(x => x.UserName).NotNull();
                    RuleFor(x => x.BirthDate).NotNull();
                    RuleFor(x => x.Email).EmailAddress();
                    RuleFor(x => x.Gender).NotNull();
            }
    }*/

}