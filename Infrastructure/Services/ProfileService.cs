using System.Net;
namespace Infrastructure.Service;

public class ProfileService(ApplicationDbContext dbContext) : IProfileService
{
    private readonly ApplicationDbContext context=dbContext;
    public async Task<Response<string>> Add(int userId,string Name)
    {
         Profile profile = new Profile(){UserId = userId,Nameprofile=Name};
        context.Profiles.Add(profile);
        await context.SaveChangesAsync();
        return new Response<string>(HttpStatusCode.OK, "added");
    }
    public async Task<PageResult<Profile>> GetAll(ProfileFilter filter,PagedQuery pagedQuery)
    {
        // return new Response<List<Profile>>(HttpStatusCode.OK, "ok", context.Profiles.ToList());
        IQueryable<Profile> query = context.Profiles.AsNoTracking();
        if(filter.Nameprofile!=null)
        {
            query = query.Where(x=>x.Nameprofile==filter.Nameprofile);
        }
        var total = await query.CountAsync();
        if(pagedQuery.Page!=0 && pagedQuery.PageSize!=0)
        {
            query = query.Skip((pagedQuery.Page-1)*pagedQuery.PageSize).Take(pagedQuery.PageSize);
        }
        var profile = query.ToList();
        var response = new PagedResult<Profile>()
        {
            Items = profile,
            Page = pagedQuery.Page,
            PageSize = pagedQuery.PageSize,
            TotalCount = total,
           TotalPages = total/pagedQuery.PageSize
         };
         return response;
    }
}