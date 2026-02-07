
namespace ExamApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class BookServiceController(IBookService  bookService):ControllerBase
{
    [HttpPost]
     public async  Task<Response<string>> AddAsync(BookDto book)
    {
        return await bookService.AddAsync(book);
    }
    [HttpDelete]
      public async Task<Response<string>> DeleteAsync(int bookid)
    {
        return await bookService.DeleteAsync(bookid);
    }
    [HttpGet]
    public async  Task<PagedResult<Book>> GetBooks(BookFilter filter, PagedQuery pagedQuery)
    {
        return await bookService.GetAsync(filter,pagedQuery);
    }
    [HttpGet("bookid")]
    public  async Task<Response<BookDto>> GetByIdAsync(int bookid)
    {
        return await bookService.GetByIdAsync(bookid);
    }
    [HttpPut]
    public async Task<Response<string>> UpdateAsync(int bookid,UpdateBookDto book)
    {
        return await bookService.UpdateAsync(bookid,book);
    }
}