using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).NotEmpty();

            //günlük fiyat model 2020 olduğunda 200 veya daha büyük olmalı
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(200).When(c => c.ModelYear == 2020);
           //RuleFor(c => c.Description).Must(StartWithA).WithMessage("Ürünler A ile başlamalı");
        }

       /* private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }*/
    }
}
