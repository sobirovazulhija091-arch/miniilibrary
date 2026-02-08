namespace Application.Interface;
using Application.DTOs;

public interface IUserService
{
    Task<Response<string>> AddAuthor(AddUserDto userDto);
    Task<PagedResult<User>> GetAll(UserFilter filter,PagedQuery pagedQuery);
    Task<Response<UserDto>> GetById(int userId);
    Task<Response<string>> Update(UpdateUserDto userDto);
    Task<Response<string>> Delete(int userId);
}