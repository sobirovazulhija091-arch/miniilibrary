using System;
using Domain.Entitis;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class AuthorRepo(ApplicationDbContext applicationDbContext): IAuthorRepo
{
    private readonly ApplicationDbContext context = applicationDbContext;

    public async Task<int> CreateAsync(Author author)
    {
        try
        {
            await context.Authors.AddAsync(author);
            await context.SaveChangesAsync();
            return author.Id;
        }
        catch
        {
            return 0;
        }
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        return context.Authors.AsEnumerable();
    }

    public Task<Author?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Author author)
    {
        throw new NotImplementedException();
    }
}