using System.Collections.Generic;
using Clipper.Domain.Entities;
using Clipper.Infra.Repositories;
using Clipper.Services;
using Clipper.Services.Base;
using Clipper.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Clipper.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        public BookController(Books repository, BookStorer storer)
        {
            Repository = repository;
            Storer = storer;
        }

        public IRepository<Book> Repository { get; }
        public BookStorer Storer { get; }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return Repository.All();
        }

        [HttpPost]
        public void Post(BookDto author)
        {
            Storer.Store(author);
        }
    }
}
