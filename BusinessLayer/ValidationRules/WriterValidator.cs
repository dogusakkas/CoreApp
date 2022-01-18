using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez").Length(2,35).WithMessage("Lütfen en az 2, en fazla 35 karakter giriniz");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi boş geçilemez");
            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz").When(x=> !string.IsNullOrEmpty(x.WriterMail));
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.WriterPassword).Must(IsPasswordValid).WithMessage("Parolanızda en az bir büyük harf, bir küçük harf ve bir de sayı içermeli ve en az 8 karakterden oluşmalıdır.");
            
        }

        private bool IsPasswordValid(string arg)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
                return regex.IsMatch(arg);
            }
            catch 
            {

                return false;
            }
            
        }
    }
}
