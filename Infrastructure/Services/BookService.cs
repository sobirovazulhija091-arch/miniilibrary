using System.Net;
namespace Infrastructure.Service;

public class BookService(ApplicationDbContext dbContext) : IBookService
{

    private readonly ApplicationDbContext context = dbContext;
    public async  Task<Response<string>> AddAsync(BookDto book1)
    {
         try
         {
            Book book = new Book
            {
               Title=book1.Title,
               PublishedYear=book1.PublishedYear,
               Genre=book1.Genre,
               AuthorId=book1.AuthorId  
            };
            //  context.Books.Add(book);
            //  await context.SaveChangesAsync();
            //  return new Response<string>(HttpStatusCode.OK,"Added successfully");
               var mapped =_mapper.Map<Book>(book1);
               await  context.Books.Add(mapped);
               await context.SaveChangesAsync();    
               return new Response<string>(HttpStatusCode.OK,"Added successfull");  
         }
         catch (System.Exception ex)
            {
              logger.LogError(ex.Message);
             return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
            }
    }
    public async Task<Response<string>> DeleteAsync(int bookid)
    {
        try
         {
            var book = await context.Books.FindAsync(bookid);
            context.Books.Remove(book);
            await context.SaveChangesAsync();
            return new Response<string>(HttpStatusCode.OK,"Deleted successfully!");   
         }
             catch (System.Exception ex)
            {
              logger.LogError(ex.Message);
             return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
            }
    }
    public  async  Task<PagedResult<Book>> GetBooks(BookFilter filter, PagedQuery pagedQuery)
    {
      /*
         //  try
         //  {
         //    // var res= context.Books.Include(a=>a.Bookloans).ToList();
         //    // return new Response<List<Book>>(HttpStatusCode.OK,"Ok", res);
         //     var result = await context.Books.ToListAsync();
         //     return _mapper.Map<List<Book>>(result);
         //  }
         //  catch (System.Exception ex)
         //  {
         //     System.Console.WriteLine(ex);
         //    return new Response<List<Book>>(HttpStatusCode.InternalServerError, $"Something went wrong!");
         //  }
         */
        IQueryable<Book> query = context.Books.AsNoTracking();
      if (filter.Title != null)
      {
         query = query.Where(x=>x.Title==filter.Title);
      }
      if (filter.PublishedYear > 0)
      {
         query = query.Where(x=>x.PublishedYear==filter.PublishedYear);
      }
      var total = await query.CountAsync();
      if(pagedQuery.Page!=0 & pagedQuery.PageSize != 0)
      {
         query = query.Skip((pagedQuery.Page-1)*pagedQuery.PageSize).Take(pagedQuery.PageSize);
      }
      var books = query.ToList();
      var response =  new PagedResult<Book>()
      {
           Items = books,
           Page = pagedQuery.Page,
           PageSize = pagedQuery.PageSize,
           TotalCount = total,
           TotalPages = total/pagedQuery.PageSize
      };
      return response;
    }
    public  async Task<Response<Book>> GetByIdAsync(int bookid)
{
          try
         {
             var res =  context.Books.Include(a=>a.Bookloans).First(a=>a.Id==bookid);
             return new Response<Book>(HttpStatusCode.OK,"OK",res);
         }
         catch (System.Exception ex)
         {
             logger.LogError(ex.Message);
             return new Response<Book>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
}
    public async Task<Response<string>> UpdateAsync(int bookid,UpdateBookDto book)
    {
         try
         {
           
             var bookk = await context.Books.FindAsync(bookid);
             bookk.Title = book.Title;
             bookk.PublishedYear = book.PublishedYear;
             bookk.Genre = book.Genre; 
             bookk.AuthorId = book.AuthorId; 
             await context.SaveChangesAsync();
               return new Response<string>(HttpStatusCode.OK,"Update successfull");
            var existing = await context.Books.FindAsync(bookid);
               _mapper.Map(book, existing);
               await context.SaveChangesAsync();
               return new Response<string>(HttpStatusCode.OK, "updated successfully!");  
             
          }
             catch (System.Exception ex)
             {
               logger.LogError(ex.Message);
               return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
             }
    }
}
