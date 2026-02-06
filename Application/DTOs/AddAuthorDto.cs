using System.ComponentModel.DataAnnotations;
namespace Aplication.DTOs;
public class AddAuthorDto
{
[Required]
    public string FullName{get;set;}=null!;
[Required]
public int BirthDate{get;set;} 
public  string Country{get;set;}=null!; 
}