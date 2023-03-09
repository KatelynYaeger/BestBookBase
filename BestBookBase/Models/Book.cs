using System;
namespace BestBookBase.Models
{
	public class Book
	{
		public Book()
		{
		}

		public int BookID { get; set; }
		public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Genre { get; set; }
        public int ReviewScore { get; set; }

    }
}

