using System;
using FluentValidation;
using LivroDeReceitas.Communication.Requests;
using LivroDeReceitas.Domain.Extensions;
using LivroDeReceitas.Exception;

namespace LivroDeReceitas.Application.UseCases.User.Register;

public class RegisterUserAccountValidator : AbstractValidator<RequestRegisterUserAccountJson>
{
    public RegisterUserAccountValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceMessagesException.VALIDATION_NAME_REQUIRED);
        RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceMessagesException.VALIDATION_EMAIL_REQUIRED);
        When(user => user.Email.IsNotEmpty(), ()=>
        {
            RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMessagesException.VALIDATION_EMAIL_INVALID);
        });

        RuleFor(user => user.Password).NotEmpty().WithMessage(ResourceMessagesException.VALIDATION_PASSWORD_REQUIRED);
    }

}
