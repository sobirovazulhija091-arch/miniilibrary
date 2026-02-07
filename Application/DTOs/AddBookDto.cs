
using System.ComponentModel.DataAnnotations;
namespace Application.DTOs;
public class AddBookDto
{
  
    [Required]
public string Title{get;set;}=null!;
    [Required]
public int PublishedYear{get;set;}
public string Genre{get;set;}=null!;
    [Required]
public int AuthorId{get;set;} 
}