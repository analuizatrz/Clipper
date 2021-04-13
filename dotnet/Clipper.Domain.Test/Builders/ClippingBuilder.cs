using System;
using Clipper.Domain;
using Clipper.Domain.Entities;

namespace Clipper.Domain.Test.Builders
{
    public class ClippingBuilder
    {
        private long Id;
        private Book Book;
        private ClippingType Type;
        private int Page;
        private int LocationStart;
        private int LocationEnd;
        private DateTime Date;
        private string Text;

        public static ClippingBuilder Default()
        {
            return new ClippingBuilder
            {
                Id = 0,
                Book = BookBuilder.Default().Build(),
                Type = ClippingType.Bookmark,
                Page = 1,
                LocationStart = 1,
                LocationEnd = 1,
                Date = new DateTime(2020, 1, 1),
                Text = "Default"
            };
        }
        public ClippingBuilder WithBook(Book book)
        {
            Book = book;
            return this;
        }
        public ClippingBuilder WithType(ClippingType type)
        {
            Type = type;
            return this;
        }
        public ClippingBuilder WithText(string text)
        {
            Text = text;
            return this;
        }
        public Clipping Build()
        {
            var clipping = new Clipping(Book, Type, Page, LocationStart, LocationEnd, Date, Text);

            if (Id > 0)
            {
                var propertyInfo = clipping.GetType().GetProperty("Id");
                propertyInfo.SetValue(clipping, Convert.ChangeType(Id, propertyInfo.PropertyType), null);
            }
            return clipping;
        }
    }
}