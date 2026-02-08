using Application.DTOs;
using Application.Responses;
using  Domain.Filter;
 using Domain.Entities;
namespace Application.Interface;
public interface IProfileService
{
   Task<Response<string>> Add(int userId,string Name);
   Task<PageResult<Profile>> GetAll(ProfileFilter filter,PagedQuery pagedQuery);
}