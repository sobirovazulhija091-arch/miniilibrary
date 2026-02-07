namespace  Domain.Filter; 

public class BooklaonFilter
{
    public DateTime LoanDate{get;set;}=DateTime.UtcNow;
 public DateTime ReturnDate{get;set;}
}