
namespace ExamApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class ProfileController(IProfileService profileService):ControllerBase
{
    [HttpPost]
     public async Task<Response<string>> Add(int userId,string Name)
    {
         return await profileService.Add(userId,Name);
    }
    [HttpGet]
    public async Task<PageResult<Profile>> GetAll(ProfileFilter filter,PagedQuery pagedQuery)
    {
        return await profileService.GetAll(filtre,pagedQuery);
    }
    
}