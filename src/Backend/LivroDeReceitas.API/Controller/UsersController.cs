using LivroDeReceitas.Application.UseCases.User.Register;
using LivroDeReceitas.Communication.Requests;
using LivroDeReceitas.Communication.Responses;
using LivroDeReceitas.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
namespace LivroDeReceitas.API.Controller;

[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> Register(
        [FromBody] RequestRegisterUserAccountJson request,
        [FromServices] IRegisterUserAccountUseCase useCase)
    {
        await useCase.Execute(request);
        return Created();
    }
}
