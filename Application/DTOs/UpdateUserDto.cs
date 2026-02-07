using System.ComponentModel.DataAnnotations;
namespace Application.DTOs;
public class UpdateUserDto
{
     public int Id{get;set;}
    [Required]
 public string FullName{get;set;}=null!;
    [Required]
 public string Email{get;set;}=null!;

}