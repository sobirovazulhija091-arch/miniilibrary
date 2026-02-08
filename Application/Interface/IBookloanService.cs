using Application.DTOs;
using Application.Responses;
using  Domain.Filter;  
 using Domain.Entities;
namespace Application.Interface;
public interface IBookloanService
{
    Task<Response<string>> AddAuthor(AddBookloanDto bloanDto);
    Task<PagedResult<Bookloan>> GetAll(BooklaonFilter filter,PageQuery pageQuery);
    Task<Response<BookloanDto>> GetById(int bloanId);
    Task<Response<string>> Update(UpdateBookloanDto bloanDto);
    Task<Response<string>> Delete(int bloanId);
}