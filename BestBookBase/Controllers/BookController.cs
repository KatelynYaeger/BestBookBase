﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BestBookBase.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository repo;

        public BookController(IBookRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var books = repo.GetAllBooks();

            return View(books);
        }

        public IActionResult ViewBook(int id)
        {
            var book = repo.GetBooks(id);

            return View(book);
        }

    }
}

