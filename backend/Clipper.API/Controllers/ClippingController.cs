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
    public class ClippingController : ControllerBase
    {
        public ClippingController(Clippings repository, ClippingStorer storer)
        {
            Repository = repository;
            Storer = storer;
        }

        IRepository<Clipping> Repository { get; }
        ClippingStorer Storer { get; }
        /// <summary>
        /// Returns all Clippings
        /// </summary>
        /// <returns>All saved clippings</returns>
        [HttpGet]
        public IEnumerable<Clipping> Get()
        {
            return Repository.All();
        }
        /// <summary>
        /// Creates a Clipping, which is a highlight (Type = 1) or a bookmark (Type = 2), of an existing book.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Clipping
        ///     {
        ///       "bookId" : 1,
        ///       "type" : 1,
        ///       "text" : "Fear of a name increases fear of the thing itself."
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        public void Post(ClippingDto author)
        {
            Storer.Store(author);
        }
    }
}
