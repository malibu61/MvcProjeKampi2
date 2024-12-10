using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Yazar Adı Boş Olamaz");
            RuleFor(x => x.AuthorSurname).NotEmpty().WithMessage("Yazar Adı Boş Olamaz");
            RuleFor(x => x.AuthorMail).NotEmpty().WithMessage("Mail Boş Olamaz");
            RuleFor(x => x.AuthorTitle).NotEmpty().WithMessage("Ünvan Boş Olamaz");
            RuleFor(x => x.AuthorName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız");
            RuleFor(x => x.AuthorName).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter giriş yapınız");
            RuleFor(x => x.AuthorSurname).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız");
            RuleFor(x => x.AuthorSurname).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter giriş yapınız");
            RuleFor(x => x.AuthorAbout).Must(x => x != null && x.ToLower().Contains("a")).WithMessage("Hakkımda alanı en az bir adet a harfi içermelidir.");

        }

    }
}
