using Clipper.Domain.Base;
using Clipper.Domain.Entities;
using Clipper.Domain.Test.Util;
using Clipper.Services;
using Xunit;
using Moq;
using Clipper.Services.Base;
using Clipper.Services.Dtos;
using Clipper.Domain.Test.Builders;
using System;

namespace Clipper.Domain.Test.Entities
{
    public class ClippingStorerTest
    {
        ClippingDto dto;
        Mock<IRepository<Clipping>> repository;
        Mock<IRepository<Book>> Books;
        ClippingStorer storer;
        Book savedBook;
        public ClippingStorerTest()
        {
            savedBook = BookBuilder.Default().WithId(3).Build();
            dto = new ClippingDto
            {
                Id = 0,
                BookId = savedBook.Id,
                Type = ClippingType.Highlight,
                Page = 2,
                LocationStart = 3,
                LocationEnd = 4,
                Date = new DateTime(2010,1,1),
                Text = "Era uma vez..."
               
            };
            repository = new Mock<IRepository<Clipping>>();
            Books = new Mock<IRepository<Book>>();
            Books.Setup(r => r.Get(dto.BookId)).Returns(savedBook);
            storer = new ClippingStorer(repository.Object, Books.Object);
        }

        [Fact]
        public void ShouldStoreClipping()
        {
            storer.Store(dto);

            repository.Verify(d => d.Save(It.Is<Clipping>(a => a.Text.Equals(dto.Text))));
        }
        
        [Fact]
        public void ShouldNotStoreClippingWithNonExistingBook()
        {
            dto.BookId = 232;

            Assert.Throws<DomainException>(() => storer.Store(dto))
                .WithErrorMessage(Resources.BookDoesNotExists);
        }

        [Fact]
        public void ShouldChangeClippingProperties()
        {
            dto.Id = 323;
            var savedClipping = ClippingBuilder.Default().Build();
            repository.Setup(c => c.Get(dto.Id)).Returns(savedClipping);

            storer.Store(dto);

            Assert.Equal(dto.BookId, savedClipping.Book.Id);
            Assert.Equal(dto.Type, savedClipping.Type);
            Assert.Equal(dto.Page, savedClipping.Page);
            Assert.Equal(dto.LocationStart, savedClipping.LocationStart);
            Assert.Equal(dto.LocationEnd, savedClipping.LocationEnd);
            Assert.Equal(dto.Text, savedClipping.Text);
        }
    }
}