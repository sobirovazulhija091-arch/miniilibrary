
namespace ExamApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class UserServiceController(IUserService userService):ControllerBase
{
    [HttpPost]
     public async Task<Response<string>> AddAsync(UserDto user)
    {
        return await userService.AddAsync(user);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int userid)
    {
        return await userService.DeleteAsync(userid);
    }
    [HttpGet]
    public async Task<PagedResult<User>> GetAll(UserFilter filter,PagedQuery pagedQuery)
    {
        return await userService.GetAsync(filter,pagedQuery);
    }
    [HttpGet("userid")]
     public async Task<Response<UserDto>> GetByIdAsync(int userid)
    {
      return await userService.GetByIdAsync(userid);   
    }
    [HttpPut]
     public async Task<Response<string>> UpdateAsync(int userid,UpdateUserDto user)
    {
        return await userService.UpdateAsync(userid,user);
    }
}