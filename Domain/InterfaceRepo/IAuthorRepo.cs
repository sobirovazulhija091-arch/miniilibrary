using System;
using Domain.Entitis;
namespace Domain.Interfaces;

public interface IAuthorRepo
{
    Task<int> CreateAsync(Author author);
    Task<Author?> GetByIdAsync(int id);
    Task<IEnumerable<Author>> GetAllAsync();
    Task<bool> UpdateAsync(Author author);
    Task<bool> DeleteAsync(int id);
}