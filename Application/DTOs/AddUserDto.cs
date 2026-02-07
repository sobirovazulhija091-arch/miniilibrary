using System.ComponentModel.DataAnnotations;
namespace Application.DTOs;
public class AddUserDto
{
    [Required]
    public string FullName{get;set;}=null!;
    [Required]
    public string Email{get;set;}=null!;
}