using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace  Aplication.DTOs;
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