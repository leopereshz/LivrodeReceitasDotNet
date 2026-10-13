using LivroDeReceitas.Communication.Requests;
using LivroDeReceitas.Domain.Repositories;
using LivroDeReceitas.Domain.Repositories.User;
using LivroDeReceitas.Domain.Security.PasswordHashing;
using LivroDeReceitas.Exception.ExceptionsBase;
using Mapster;

namespace LivroDeReceitas.Application.UseCases.User.Register;

public class RegisterUserAccountUseCase : IRegisterUserAccountUseCase
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;

    private readonly IUnitOfWork _unitofwork;

    public RegisterUserAccountUseCase(IPasswordHasher passwordHasher, IUserWriteOnlyRepository userWriteOnlyRepository, IUnitOfWork unitofwork)
    {
        _passwordHasher = passwordHasher;
        _userWriteOnlyRepository = userWriteOnlyRepository;
        _unitofwork = unitofwork;
    }

    public async Task Execute(RequestRegisterUserAccountJson request)
    {
        ValidateAndThrowOnFailures(request);

        var user = request.Adapt<Domain.Entities.User>();
        user.Password = _passwordHasher.HashPassword(request.Password);
        await _userWriteOnlyRepository.Add(user);
        await _unitofwork.Commit();
    }

    private void ValidateAndThrowOnFailures(RequestRegisterUserAccountJson request)
    {
        var validator = new RegisterUserAccountValidator();
        var result = validator.Validate(request);

        if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }

    }
}
