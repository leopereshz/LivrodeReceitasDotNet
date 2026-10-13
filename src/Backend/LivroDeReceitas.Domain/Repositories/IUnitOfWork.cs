using System;

namespace LivroDeReceitas.Domain.Repositories;

public interface IUnitOfWork
{
    Task Commit();
}
