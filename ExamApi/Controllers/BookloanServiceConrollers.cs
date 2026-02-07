
namespace ExamApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class BookloanServiceControllers(IBookloanService bookloanService):ControllerBase
{
    [HttpPost]
      public async Task<Response<string>> AddAsync(BookloanDto bookloan)
    {
        return await bookloanService.AddAsync(bookloan);
    }
    [HttpDelete]
     public async Task<Response<string>> DeleteAsync(int bookloanid)
    {
        return await  bookloanService.DeleteAsync(bookloanid);
    }
    [HttpGet]
     public async Task<PagedResult<Bookloan>> GetAll(BookloanFilter filter,PageQuery pageQuery)
    {
        return await bookloanService.GetAsync(filter,pageQuery);
    }
    [HttpGet("bookloanid")]
     public  async Task<Response<BookloanDto>> GetByIdAsync(int bookloanid)
    {
        return await bookloanService.GetByIdAsync(bookloanid);
    }
    [HttpPut]
     public async Task<Response<string>> UpdateAsync(int bookloanid,UpdateBookloanDto bookloan)
    {
        return await bookloanService.UpdateAsync(bookloanid,bookloan);
    }
    [HttpPut("return")]
     public async Task<Response<Bookloan>> ReturnAsync(int bookloanid)
    {
        return await bookloanService.ReturnAsync(bookloanid);
    }
}