using System.Net;
namespace Infrastructure.Service;
public class AuthorService(ApplicationDbContext dbcontext): IAuthorService
{
    private readonly ApplicationDbContext context = dbContext;

    public async Task<Response<string>> AddAuthor(AddAuthorDto authorDto)
    {
        var author = new Author()
        {
            FullName = authorDto.FullName,
            BirthDate= authorDto.BirthDate,
            Country = authorDto.Country
        };
         var mapped =_mapper.Map<Author>(authorDto);
            await  context.Authors.Add(mapped);
             await context.SaveChangesAsync();    
        return new Response<string>(HttpStatusCode.OK, "Added successfully!");
    }
    public async Task<Response<string>> Delete(int authorId)
    {
        var a = await context.Authors.FindAsync(authorId);
            context.Authors.Remove(a);
               await context.SaveChangesAsync();
            return new Response<string>(HttpStatusCode.OK,"Deleted successfully!");   
    }
    public async Task<Response<List<AuthorDto>>> GetAll()
    {
        // var res = await context.GetAllAsync();
        // var authors  = res.Select(a=> new AuthorDto()
        // {
        //         Id = a.Id,
        //         FullName = a.FullName,
        //         Country = a.Country
        // }).ToList();
        // return new Response<List<AuthorDto>>(HttpStatusCode.OK, "ok", authors); 
         IQueryable<Author> query =  context.Authors.AsNoTracking();
       if(filter.FullName!=null)
       {
        query =query.Where(x=>x.FullName==filter.FullName);
      }
       if(filter.Country!=null)
       {
        query =query.Where(x=>x.Country==filter.Country);
      }
       if(filter.BirthDate>0 )
       {
        query=query.Where(x=>x.BirthDate==filter.BirthDate);
        }
       var total= await query.CountAsync();
       if(pagedQuery.Page!=0 && pagedQuery.PageSize!=0)
        {
            query = query.Skip((pagedQuery.Page-1)*pagedQuery.PageSize).Take(pagedQuery.PageSize);
        }
        var  authors = query.ToList();
        var response =  new PagedResult<Author>()
      {
           Items =   authors,
           Page = pagedQuery.Page,
           PageSize = pagedQuery.PageSize,
           TotalCount = total,
           TotalPages = total/pagedQuery.PageSize
      };
      return response; 
    }
    public Task<Response<AuthorDto>> GetById(int authorId)
    {
        try
         {
            var res =  context.Authors.FindAsync(authorId);
        return new Response<Author>(HttpStatusCode.OK,"OK",res);
         }
         catch (System.Exception ex)
         {
              logger.LogError(ex.Message);
             return new Response<Author>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
    }
    public Task<Response<string>> Update(UpdateAuthorDto authorDto)
    {
       var a = await context.Authors.FindAsync();
            a.FullName = authorDto.FullName;
            a.BirthDate= authorDto.BirthDate;
            a.Country = authorDto.Country;
            await context.SaveChangesAsync();
            return new Response<string>(HttpStatusCode.OK,"Update successfull");  
    }
}