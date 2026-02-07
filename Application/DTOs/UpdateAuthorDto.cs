using System.ComponentModel.DataAnnotations;
namespace Application.DTOs;
public class UpdateAuthorDto
{
    
    public int Id{get;set;}
    [Required]
    public string FullName{get;set;}=null!;
    [Required]
     public int BirthDate{get;set;} 
     [Required]
     public  string Country{get;set;}=null!; 
}