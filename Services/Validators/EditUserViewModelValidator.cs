using FluentValidation;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators
{
    public class EditUserViewModelValidator : AbstractValidator<EditUserViewModel>
    {
        public EditUserViewModelValidator()
        {
           RuleFor(viewModel => viewModel.User).SetValidator(new UserValidator());
        }
    }

}

