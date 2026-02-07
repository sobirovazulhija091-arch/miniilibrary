using System.Net;
namespace Infrastructure.Service;
public class BookloanService(ApplicationDbContext dbContext) : IBookloanService
{
    private readonly ApplicationDbContext context = dbContext;
   
    public async Task<Response<string>> AddAsync(BookloanDto bookloan1)
    {
        Bookloan bookloan = new Bookloan
            {
               UserId=bookloan1.UserId,
               BookId=bookloan1.BookId ,
                ReturnDate=bookloan1.ReturnDate   
            };
        try
         {  
              var mapped =_mapper.Map<Bookloan>(bookloan1);
            await  context.Bookloans.Add(mapped);
             await context.SaveChangesAsync();    
               return new Response<string>(HttpStatusCode.OK,"Added successfull");  
         }
         catch (System.Exception ex)
         {
              logger.LogError(ex.Message);
             return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
    }
    public async Task<Response<string>> DeleteAsync(int bookloanid)
    {
        try
         {
               var bookloan = await context.Bookloans.FindAsync(bookloanid);
              context.Bookloans.Remove(bookloan);
               await context.SaveChangesAsync();
               return new Response<string>(HttpStatusCode.OK,"Delete successfull");        
         }
         catch (System.Exception ex)
         {
              logger.LogError(ex.Message);
             return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
    }
    public async  Task<PagedResult<Bookloan>> GetAll(BookloanFilter filter,PagedQuery pagedQuery)
    {
        /* try
        // {
        //      return new Response<List<Bookloan>>(HttpStatusCode.OK,"ok",await context.Bookloans.ToListAsync());
        //      var result = await context.Bookloans.ToListAsync();
        //      return _mapper.Map<List<Bookloan>>(result);
        //  }
        // catch (System.Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        //     return new Response<List<Bookloan>>(HttpStatusCode.InternalServerError, $"Something went wrong!");
        } */
       IQueryable<Bookloan> query =  context.Bookloans.AsNoTracking();
       if(filter.LoanDate>0)
       {
        query =query.Where(x=>x.LoanDate==filter.LoanDate);
      }
       if(filter.ReturnDate>0 && filter.ReturnDate>filter.LoanDate)
       {
        query=query.Where(x=>x.ReturnDate==filter.ReturnDate);
        }
       var total= await query.CountAsync();
       if(pagedQuery.Page!=0 && pagedQuery.PageSize!=0)
        {
            query = query.Skip((pagedQuery.Page-1)*pagedQuery.PageSize).Take(pagedQuery.PageSize);
        }
        var  booklaon = query.ToList();
        var response =  new PagedResult<Bookloan>()
      {
           Items =  booklaon,
           Page = pagedQuery.Page,
           PageSize = pagedQuery.PageSize,
           TotalCount = total,
           TotalPages = total/pagedQuery.PageSize
      };
      return response;
    }
    public  async Task<Response<BookloanDto>> GetByIdAsync(int bookloanid)
    {
        try
         {
            var loan = await context.Bookloans.FindAsync(bookloanid);
            return new Response<Bookloan>(HttpStatusCode.OK,"oK",loan); 
         }
         catch (System.Exception ex)
         {
              logger.LogError(ex.Message);
             return new Response<Bookloan>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
    }
    public async Task<Response<string>> UpdateAsync(int bookloanid,UpdateBookloanDto bookloan)
    {
         try
         {
             
             var loan = await context.Bookloans.FindAsync(bookloanid);
               loan.BookId=bookloan.BookId;
               loan.UserId=bookloan.UserId;
               loan.LoanDate=bookloan.LoanDate;
               loan.ReturnDate=loan.ReturnDate; 
               await context.SaveChangesAsync();
               return new Response<string>(HttpStatusCode.OK,"Update successfull");  
               var existing = await context.Bookloans.FindAsync(bookloanid);
               _mapper.Map(bookloan, existing);
               await context.SaveChangesAsync();
               return new Response<string>(HttpStatusCode.OK, "updated successfully!");
         }
         catch (System.Exception ex)
         {
              logger.LogError(ex.Message);
             return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
    }
    public async Task<Response<Bookloan>> ReturnAsync(int bookloanid)
    {
        try
        { 
             var  loan = await context.Bookloans.FindAsync(bookloanid);

              if (loan==null)
             {
               return new Response<Bookloan>(HttpStatusCode.NotFound,"Can not Find");
             }
                 loan.ReturnDate=DateTime.UtcNow;
                 await context.SaveChangesAsync();
               return new Response<Bookloan>(HttpStatusCode.OK,"Returned successfull");    
        }  
         catch (System.Exception ex)
          {
              logger.LogError(ex.Message);
             return new Response<Bookloan>(HttpStatusCode.InternalServerError,"Internal Server Error");
          }
         }
    
 }
