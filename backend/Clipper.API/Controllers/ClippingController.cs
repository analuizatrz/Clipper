using System.Collections.Generic;
using Clipper.Domain.Entities;
using Clipper.Infra.Repositories;
using Clipper.Services.Abstractions;
using Clipper.Services.Base;
using Clipper.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Clipper.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClippingController : ControllerBase
    {
        public ClippingController(Clippings repository, IClippingStorer storer, IClippingParserStorer parserStorer)
        {
            Repository = repository;
            Storer = storer;
            ParserStorer = parserStorer;
        }

        private IRepository<Clipping> Repository { get; }
        private IClippingStorer Storer { get; }
        private IClippingParserStorer ParserStorer { get; }

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

        /// <summary>
        /// Creates multiple clippings by parsing the content provided. 
        /// </summary>
        /// <remarks>
        /// Author and book will be created as well if there is not a author or book with the specified name in the system.
        /// 
        /// Sample request:
        ///
        /// "A arte de ser leve (Ferreira, Leila)\n- Seu destaque ou posição 1896-1897 | Adicionado: terça-feira, 29 de maio de 2018 10:37:11\n“Namore muito, mas não se case não”."
        ///
        /// </remarks>
        [HttpPost("Parse")]
        public void Parse([FromBody] string content)
        {
            ParserStorer.Store(content);
        }
    }
}
