using System.Data.SQLite;
using API.Models.Interfaces;

namespace API.Models
{
    public class SaveBook : IInsertBook
    {
        public void InsertBook(Book value)
        {
            string cs = @"URI=file:D:\Spring 2022\MIS321\source\repos\bookdatabase\book.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"INSERT INTO books (title, author) VALUES(@title, @author)";
            cmd.Parameters.AddWithValue("@title", value.Title);
            cmd.Parameters.AddWithValue("@author", value.Author);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}