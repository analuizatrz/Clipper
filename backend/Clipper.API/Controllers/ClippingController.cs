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

        public IRepository<Clipping> Repository { get; }
        public ClippingStorer Storer { get; }

        [HttpGet]
        public IEnumerable<Clipping> Get()
        {
            return Repository.All();
        }

        [HttpPost]
        public void Post(ClippingDto author)
        {
            Storer.Store(author);
        }
    }
}
