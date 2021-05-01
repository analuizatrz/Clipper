using System.Collections.Generic;
using Clipper.Domain.Entities;
using Clipper.Infra.Repositories;
using Clipper.Services;
using Clipper.Services.Abstractions;
using Clipper.Services.Base;
using Clipper.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Clipper.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        public BookController(Books repository, IBookStorer storer)
        {
            Repository = repository;
            Storer = storer;
        }

        IRepository<Book> Repository { get; }
        IBookStorer Storer { get; }

        /// <summary>
        /// Returns all Books
        /// </summary>
        /// <returns>All saved books</returns>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return Repository.All();
        }

        /// <summary>
        /// Creates a Book, of an existing author
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Book
        ///     {
        ///       "Name": "Harry Potter and the Sorcerer's Stone",
        ///       "AuthorId": 1,
        ///       "Description": "A book of witchcraft and wizardry",
        ///       "Edition": 1,
        ///       "Year": 1999
        ///     }
        ///
         /// </remarks>
        [HttpPost]
        public void Post(BookDto author)
        {
            Storer.Store(author);
        }
    }
}
