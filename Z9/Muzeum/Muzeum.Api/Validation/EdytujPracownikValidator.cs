using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Muzeum.Api.BindingModels;
using FluentValidation;

namespace Muzeum.Api.Validation
{
    public class EdytujPracownikValidator : AbstractValidator<EdytujPracownik>
    {
        public EdytujPracownikValidator()
        {
            RuleFor(x => x.ImieP).NotEmpty();
            RuleFor(x => x.NazwiskoP).NotEmpty();
            RuleFor(x => x.Pesel).NotEmpty();
            RuleFor(x => x.plec).NotEmpty();
            RuleFor(x => x.DataZatrudnienia).NotEmpty();
            RuleFor(x => x.DataUrodzin).NotEmpty();
        }
    }
}
