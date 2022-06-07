using System.Collections.Generic;

namespace API.Models.Interfaces
{
    public interface IGetAllBooks
    {
        List<Book> GetAllBooks();
        
    }
}