using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).Must(x => x != null && x.Contains("@")).WithMessage("Mail adresi '@' içermelidir.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adını boş geçemezsiniz.");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı adına minimum 3 karakter girebilirsiniz.");
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresini boş geçemezsiniz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Konuya maksimum 50 karakter girebilirsiniz.");
        }
    }
}
