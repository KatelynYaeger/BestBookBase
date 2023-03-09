using System;
using BestBookBase.Models;

namespace BestBookBase
{
	public interface IBookRepository
	{
		public IEnumerable<Book> GetAllBooks();
	}

}

