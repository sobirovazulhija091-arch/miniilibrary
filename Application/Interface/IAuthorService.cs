namespace Application.Interface;
using Application.DTOs;
public interface IAuthorService
{
    Task<Response<string>> AddAuthor(AddAuthorDto authorDto);
    Task<PagedResult<AuthorDto>> GetAll(AuthorFilter filter,PageQuery pageQuery);
    Task<Response<AuthorDto>> GetById(int authorId);
    Task<Response<string>> Update(int authorid,UpdateAuthorDto authorDto);
    Task<Response<string>> Delete(int authorId);
}