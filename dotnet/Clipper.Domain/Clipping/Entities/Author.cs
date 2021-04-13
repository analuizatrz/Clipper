using Clipper.Domain.Base;

namespace Clipper.Domain.Clipping.Entities
{
    public class Author : EntityWithName
    {
        public Author(string name)
        {
            DomainValidator
                .Create()
                .When(name.IsNullOrEmpty(), Resources.NameShouldntBeEmpty)
                .ThrowExceptionIfAnyErrors();

            Name = name;
        }
    }
}