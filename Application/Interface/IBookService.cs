using Application.DTOs;
using  Domain.Filter;  
using Application.Responses;
 using Domain.Entities;
namespace Application.Interface;
public interface IBookService
{
    Task<Response<string>> AddAuthor(AddBookDto bookDto);
   Task<PagedResult<Book>> GetBooks(BookFilter filter, PagedQuery pagedQuery);
    Task<Response<BookDto>> GetById(int bookId);
    Task<Response<string>> Update(UpdateBookDto bookDto);
    Task<Response<string>> Delete(int bookId);
}