using System;
using Clipper.Domain.Base;
using Clipper.Domain;

namespace Clipper.Domain.Entities
{
    public class Clipping : Entity
    {
        public Clipping(Book book, ClippingType type, int page, int locationStart, int locationEnd, DateTime date, string text)
        {
            DomainValidator
                .Create()
                .When(type == ClippingType.None, Resources.ClippingShouldBeHighlightOrBookmark)
                .When((type == ClippingType.Highlight) && text.IsNullOrEmpty(), Resources.HighlightShouldHaveANonNullOrEmptyText)
                .When(Book.IsNull(), Resources.BookShouldntBeEmpty)
                .ThrowExceptionIfAnyErrors();

            Book = book;
            Type = type;
            Page = page;
            LocationStart = locationStart;
            LocationEnd = locationEnd;
            Date = date;
            Text = text;
        }

        public Book Book { get; private set; }
        public ClippingType Type { get; private set; }
        public int Page { get; private set; }
        public int LocationStart { get; private set; }
        public int LocationEnd { get; private set; }
        public DateTime Date { get; private set; }
        public string Text { get; private set; }
    }
}