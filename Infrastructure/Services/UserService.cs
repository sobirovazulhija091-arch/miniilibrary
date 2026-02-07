using System.Net;
namespace Infrastructure.Service;

public class UserService(ApplicationDbContext dbContext) : IUserService
{

    private readonly ApplicationDbContext context = dbContext;
    public async Task<Response<string>> AddAsync(UserDto user1)
    {
         try
         {
            // User user = new User
            // {
            //   FullName=user1.FullName,
            //   Email=user1.Email  
            // };
            //   context.Users.Add(user);
            //   await context.SaveChangesAsync();
            //    return new Response<string>(HttpStatusCode.OK,"Added successfull");  
             var mapped =_mapper.Map<User>(user1);
               await  context.Users.Add(mapped);
               await context.SaveChangesAsync();    
               return new Response<string>(HttpStatusCode.OK,"Added successfull"); 
             
         }
         catch (System.Exception ex)
            {
              logger.LogError(ex.Message);
             return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
            }
    }
    public async Task<Response<string>> DeleteAsync(int userid)
    {
        try
         {
             var res = await context.Users.FindAsync(userid);
             context.Users.Remove(res);
             await context.SaveChangesAsync();
               return new Response<string>(HttpStatusCode.OK,"Delete successfull");  
             }
             catch (System.Exception ex)
            {
              logger.LogError(ex.Message);
             return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
            }
    }
    public async Task<PagedResult<User>> GetAll(UserFilter filter,PagedQuery pagedQuery)
    {
      /*
      //  var res = await context.Users.Include(a=>a.Profile).ToListAsync();
      //  return new Response<List<User>>(HttpStatusCode.OK,"ok",res);
      //  var result = await context.Users.ToListAsync();
      //        return _mapper.Map<List<User>>(result);
      */
       IQueryable<User> query = context.Users.AsNoTracking();
       if(filter.FullName!=null)
    {
      query = query.Where(x=>x.FullName==filter.FullName);
    }
        if(filter.Email!=null)
    {
      query = query.Where(x=>x.Email==filter.Email);
    }
    var total = await query.CountAsync();
    if(pagedQuery.Page!=0 && pagedQuery.PageSize!=0)
    {
      query = query.Skip((pagedQuery.Page-1)*pagedQuery.PageSize).Take(pagedQuery.PageSize);
    }
    var user = query.ToList();
    var response = new PagedResult<User>()
    {
       Items = user,
       Page = pagedQuery.Page,
       PageSize = pagedQuery.PageSize,
      TotalCount = total,
        TotalPages = total/pagedQuery.PageSize
    };
    return response;
    }
    public async Task<Response<UserDto>> GetByIdAsync(int userid)
    {
        try
         {
               var res = await context.Users.FindAsync(userid);
                return new Response<User>(HttpStatusCode.OK,"Get successfull",res);      
         }
         catch (System.Exception ex)
         {
             logger.LogError(ex.Message);
             return new Response<User>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
    }
    public async Task<Response<string>> UpdateAsync(int userid,UpdateUserDto user)
    {
        try
         {
            //   var  userss = await context.Users.FindAsync(userid);  
            //  userss.FullName=user.FullName;
            //  userss.Email=user.Email;
            // await context.SaveChangesAsync();
            //    return new Response<string>(HttpStatusCode.OK,"Update successfull");  
              var existing = await context.Users.FindAsync(userid);
               _mapper.Map(user, existing);
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