using System;
using System.Data;
using System.IO;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Business.ValidationRules.FluentValidation
{
    public class ImageValidator : AbstractValidator<IFormFile>
    {
        public ImageValidator()
        {
            RuleFor(e => e.FileName).NotNull();
        }

        private bool CheckFileTypeImage(string arg)
        {
            var type = Path.GetExtension(arg);
            if (type != ".jpeg" && type != ".png" && type != ".jpg")
            {
                return false;
            }
            return true;
        }
    }
}