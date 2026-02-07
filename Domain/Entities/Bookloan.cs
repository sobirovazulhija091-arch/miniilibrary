using System.Text.Json.Serialization;


namespace  Domain.Entities;  
public class Bookloan
{
 public int Id{get;set;} 
 public int BookId{get;set;}
 public int UserId{get;set;}
 [JsonIgnore]
 public Book? Book {get;set;}
 [JsonIgnore]
 public User? User{get;set;}
 public DateTime LoanDate{get;set;}=DateTime.UtcNow;
 public DateTime ReturnDate{get;set;}
 
}