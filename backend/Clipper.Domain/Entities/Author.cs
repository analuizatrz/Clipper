using Clipper.Domain.Base;

namespace Clipper.Domain.Entities
{
    public class Author : EntityWithName
    {
        public Author(string name)
        {
            ChangeName(name);
        }
        public void ChangeName(string name)
        {
            DomainValidator
                .Create()
                .When(name.IsNullOrEmpty(), Resources.NameShouldntBeEmpty)
                .ThrowExceptionIfAnyErrors();

            Name = name;
        }
    }
}