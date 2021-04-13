using System;
using Clipper.Domain.Entities;

namespace Clipper.Domain.Test.Builders
{
    public class BookBuilder
    { 
        private long Id;
        private string Name;
        private Author Author;
        private string Description;
        private int Edition;
        private int Year;

        public static BookBuilder Default()
        {
            return new BookBuilder
            {
                Id = 0,
                Name = "Default",
                Author = new Author("Default"),
                Description = "Default",
                Edition = 1,
                Year = 2000
            };
        }
        public BookBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public BookBuilder WithAuthor(Author author)
        {
            Author = author;
            return this;
        }

        public BookBuilder WithDescription(string description)
        {
            Description = description;
            return this;
        }

        public BookBuilder WithEdition(int edition)
        {
            Edition = edition;
            return this;
        }

        public BookBuilder WithYear(int year)
        {
            Year = year;
            return this;
        }

        public Book Build()
        {
            var book = new Book(Name, Author, Description, Edition, Year);

            if (Id > 0)
            {
                var propertyInfo = book.GetType().GetProperty("Id");
                propertyInfo.SetValue(book, Convert.ChangeType(Id, propertyInfo.PropertyType), null);
            }
            return book;
        }
    }
}