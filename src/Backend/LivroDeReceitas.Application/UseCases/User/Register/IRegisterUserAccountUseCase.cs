
using System;
using LivroDeReceitas.Communication.Requests;

namespace LivroDeReceitas.Application.UseCases.User.Register;

public interface IRegisterUserAccountUseCase
{
    Task Execute(RequestRegisterUserAccountJson request);
}
