using System;
using Domain.Entitis;

namespace Domain.Interfaces;

public interface IUserRepo
{
    Task<int> CreateAsync(User user);
    Task<User?> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
    Task<IEnumerable<User>> GetByAuthorIdAsync(int authorId);
    Task<bool> UpdateAsync(Book book);
    Task<bool> DeleteAsync(int id);    
}