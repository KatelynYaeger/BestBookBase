using System;
using System.Data;
using BestBookBase.Models;
using Dapper;

namespace BestBookBase
{
	public class BookRepository: IBookRepository
	{
		private readonly IDbConnection _conn;

		public BookRepository(IDbConnection conn)
		{
			_conn = conn;

		}

        public IEnumerable<Book> GetAllBooks()
        {
			return _conn.Query<Book>("SELECT * FROM BOOKS;");
        }

        public Book GetBooks(int id)
        {
            return _conn.QuerySingle<Book>("SELECT * FROM BOOKS WHERE BOOKID = @id;",
                new { id = id });
        }
    }
}

