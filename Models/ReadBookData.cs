using System.Collections.Generic;
using System.Data.SQLite;
using API.Models.Interfaces;

namespace API.Models
{
    public class ReadBookData : IGetAllBooks, IGetBook
    {
        public List<Book> GetAllBooks()
        {
            List<Book> allBooks = new List<Book>();

            string cs = @"URI=file:D:\Spring 2022\MIS321\source\repos\bookdatabase\book.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * from books";
            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Book newBook = new Book() { Id = rdr.GetInt32(0), Title=rdr.GetString(1), Author=rdr.GetString(2) };
                allBooks.Add(newBook);
            }

            return allBooks;
        }

        public Book GetBook(int id)
        {
            string cs = @"URI=file:D:\Spring 2022\MIS321\source\repos\bookdatabase\book.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * from books WHERE id = @id";
            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Book() { Id = rdr.GetInt32(0), Title=rdr.GetString(1), Author=rdr.GetString(2) };
        }
    }
}
