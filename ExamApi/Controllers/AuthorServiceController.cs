
namespace ExamApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorServiceController(IAuthorService authorService): ControllerBase
{
    [HttpPost]
    public async Task<Response<string>>  AddAuthor(AuthorDto author)
    {
        return await authorService. AddAuthor(author);
    }

    [HttpDelete]
     public async Task<Response<string>> Delete(int authorid)
    {
        return await authorService.Delete(authorid);
    }
    [HttpGet]
     public async    Task<PagedResult<Author>> GetAll(AuthorFilter filter,PageQuery pageQuery)
    {
        return await authorService.GetAll(filter,pageQuery);
    }
    [HttpGet("authorid")]

    public async Task<Response<Author>>  GetById(int authorid)
    {
         return await authorService.GetById(authorid);
    }
    [HttpPut]
     public async Task<Response<string>> Update(int authorid,UpdateAuthorDto author)
    {
        return await authorService.Update(authorid,author);
    }
}
