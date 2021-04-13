using System;
using Clipper.Domain;

namespace Clipper.Services.Dtos
{
    public class ClippingDto
    {
        public long Id { get; set; }
        public long BookId { get; set; }
        public ClippingType Type { get; set; }
        public int Page { get; set; }
        public int LocationStart { get; set; }
        public int LocationEnd { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }
}