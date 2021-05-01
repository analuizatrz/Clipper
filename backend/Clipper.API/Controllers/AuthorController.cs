using System.Collections.Generic;
using Clipper.Domain.Entities;
using Clipper.Services;
using Clipper.Services.Base;
using Clipper.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Clipper.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        public AuthorController(IRepository<Author> repository, AuthorStorer storer)
        {
            Repository = repository;
            Storer = storer;
        }

        public IRepository<Author> Repository { get; }
        public AuthorStorer Storer { get; }

        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return Repository.All();
        }

        [HttpPost]
        public void Post(AuthorDto author)
        {
            Storer.Store(author);
        }
    }
}
