using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresi boş olamaz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj boş olamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş olamaz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız.");
            RuleFor(x => x.ReceiverMail).Must(x => x != null && x.Contains("@")).WithMessage("Mail adresi '@' içermelidir.");
            RuleFor(x => x.MessageContent).MaximumLength(100).WithMessage("100'den fazla karakter girişi yapılamaz.");


        }
    }
}
