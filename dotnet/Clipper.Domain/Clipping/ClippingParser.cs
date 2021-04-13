using System;
using System.Linq;

namespace Clipper.Domain.Clipping
{
    public class ClippingParser
    {
        private string TypeHighlightToken = "destaque";
        private string TypeBookmarkToken = "marcador";
        private string PositionToken = "ou posição";

        private string Separator = "==========";
        public ClippingModel Parse(string content){
            var clipping = new ClippingModel();
            var lines = content.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var firstLine = lines.First().Replace(')', ' ').Split('(');
            (clipping.Book, clipping.Author) = (firstLine[0].Trim(), firstLine[1].Trim());

            var secondLine = lines[1].Split('|');

            clipping.Type = secondLine[0].Contains(TypeHighlightToken)
                        ? ClippingType.Highlight
                        : secondLine[0].Contains(TypeBookmarkToken)
                            ? ClippingType.Bookmark
                            : ClippingType.None;

            clipping.Position = secondLine[0]
                                .Split(new string[] { PositionToken }, StringSplitOptions.RemoveEmptyEntries)
                                .Last()
                                .Trim()
                                .Split('-');
            clipping.Date = lines[1].Split(',').Last().Trim();

            clipping.Text = clipping.Type == ClippingType.Highlight ? lines.LastOrDefault() : string.Empty;

            return clipping;
        }
    }
}