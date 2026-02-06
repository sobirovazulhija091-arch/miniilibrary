using System;
using Domain.Entitis;

namespace Domain.Interfaces;

public interface IBookloanRepo
{
    Task<int> CreateAsync(Bookloan bookloan);
    Task<Bookloan?> GetByIdAsync(int id);
    Task<IEnumerable<Bookloan>> GetAllAsync();
    Task<bool> UpdateAsync(Bookloan bookloan);
    Task<bool> DeleteAsync(int id);
}