﻿using System;
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

        public void UpdateBook(Book book)
        {
            _conn.Execute("UPDATE BOOKS SET Title = @title,ReviewScore = @reviewscore WHERE BookID = @id",
                new { title = book.Title, reviewscore = book.ReviewScore, id = book.BookID });
        }

        public void InsertBook(Book bookToInsert)
        {
            _conn.Execute("INSERT INTO books (Title, AuthorName, Genre, ReviewScore) Values (@title, @authorname, @genre, @reviewscore);",
                new { title = bookToInsert.Title, bookToInsert.AuthorName, bookToInsert.Genre, bookToInsert.ReviewScore });
        }

        public void DeleteBook(Book book)
        {
            _conn.Execute("DELETE FROM BOOKS WHERE BOOKID = @id;",
                new { id = book.BookID });
        }
    }
}

