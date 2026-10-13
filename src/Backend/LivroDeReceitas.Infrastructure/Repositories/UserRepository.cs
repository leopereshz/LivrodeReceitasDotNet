
using System;
using LivroDeReceitas.Domain.Entities;
using LivroDeReceitas.Domain.Repositories.User;
using LivroDeReceitas.Infrastructure.DataAccess;

namespace LivroDeReceitas.Infrastructure.Repositories;

internal sealed class UserRepository : IUserWriteOnlyRepository
{
    private readonly LivroDeReceitasDbContext _dbContext;
    public UserRepository(LivroDeReceitasDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(User user) => await _dbContext.Users.AddAsync(user);
}
