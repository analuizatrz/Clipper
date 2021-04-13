namespace Clipper.Domain
{
    public class ClippingModel
    {
        public string Date { get; set; }
        public string Author { get; set; }
        public string Book { get; set; }
        public string [] Position { get; set; }
        public ClippingType Type { get; set; }
        public string Text { get; set; }
    }
}