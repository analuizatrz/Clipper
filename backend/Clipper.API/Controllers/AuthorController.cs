using System.Collections.Generic;
using Clipper.Domain.Entities;
using Clipper.Services;
using Clipper.Services.Base;
using Clipper.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Clipper.API.Controllers
{
    /// <summary>
    /// Book's author endpoint
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        /// <summary>
        /// Book's author
        /// </summary>
        public AuthorController(IRepository<Author> repository, AuthorStorer storer)
        {
            Repository = repository;
            Storer = storer;
        }

        IRepository<Author> Repository { get; }
        AuthorStorer Storer { get; }
        /// <summary>
        /// Returns all Authors
        /// </summary>
        /// <returns>All saved authors</returns>

        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return Repository.All();
        }

        /// <summary>
        /// Creates an Author
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Author
        ///     {
        ///       "name": "J. K. Rowling"
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        public void Post(AuthorDto author)
        {
            Storer.Store(author);
        }
    }
}
