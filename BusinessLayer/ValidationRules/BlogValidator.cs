using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığını boş geçemezsiniz").Length(5, 150).WithMessage("Başlık en az 5 karakter en fazla 150 karakter olabilir");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriğini boş geçemezsiniz").MinimumLength(5).WithMessage("İçerik 5 karakterden fazla olmalı");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog görseli boş geçemezsiniz");


        }
    }
}
