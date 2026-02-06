using System.ComponentModel.DataAnnotations;
namespace  Aplication.DTOs;
 public class UpdateBookloanDto
 {
     public int Id{get;set;} 
    [Required]
   public int BookId{get;set;}
    [Required]
    public int UserId{get;set;}
   
   public DateTime LoanDate{get;set;}=DateTime.UtcNow;

 public DateTime ReturnDate{get;set;}=DateTime.UtcNow;
 }