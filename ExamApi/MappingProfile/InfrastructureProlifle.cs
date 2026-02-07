using ExamApi.DTOs;
using ExamApi.Entites;
namespace ExamApi.MappingProflie;
public class InfrastructureProfile : AutoMapper.Profile
{
    public InfrastructureProfile()
    {
        CreateMap<Author, AuthorDto>();
        CreateMap<AuthorDto, Author>();
        CreateMap<UpdateAuthorDto, Author>();
    }
}
