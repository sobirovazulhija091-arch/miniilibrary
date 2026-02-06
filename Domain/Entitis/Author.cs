using System.ComponentModel.DataAnnotations;

namespace Domain.Entitis;
public class Author{
public int Id{get;set;}
[MaxLength(120),Required]
public string FullName{get;set;}=null!;
public int BirthDate{get;set;} 
public  string Country{get;set;}=null!;
public List<Book> Books{get;set;}=[];
}