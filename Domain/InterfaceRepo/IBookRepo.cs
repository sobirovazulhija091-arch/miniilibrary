using System;
using Domain.Entitis;

namespace Domain.Interfaces;

public interface IBookRepo
{
    Task<int> CreateAsync(Book book);
    Task<Book?> GetByIdAsync(int id);
    Task<IEnumerable<Book>> GetAllAsync();
    Task<IEnumerable<Book>> GetByAuthorIdAsync(int authorId);
    Task<bool> UpdateAsync(Book book);
    Task<bool> DeleteAsync(int id);    
}