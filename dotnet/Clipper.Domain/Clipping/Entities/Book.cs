using Clipper.Domain.Base;

namespace Clipper.Domain.Clipping.Entities
{
    public class Book : EntityWithName
    {
        public Book(string name, Author author, string description, int edition, int year)
        {
            DomainValidator
                .Create()
                .When(name.IsNullOrEmpty(), Resources.NameShouldntBeEmpty)
                .When(author.IsNull(), Resources.AuthorShouldntBeEmpty)
                .ThrowExceptionIfAnyErrors();

            Name = name;
            Author = author;
            Description = description;
            Edition = edition;
            Year = year;
        }
        public Author Author { get; private set; }
        public string Description { get; private set; }
        public int Edition { get; private set; }
        public int Year { get; private set; }
    }
}