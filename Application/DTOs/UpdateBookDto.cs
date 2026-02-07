using System.ComponentModel.DataAnnotations;
namespace Application.DTOs;
public class UpdateBookDto
{
    public int Id{get;set;}
    [Required]
 public string Title{get;set;}=null!;
    [Required]
public int PublishedYear{get;set;}
    [Required]
public string Genre{get;set;}=null!;
    [Required]
public int AuthorId{get;set;} 
}