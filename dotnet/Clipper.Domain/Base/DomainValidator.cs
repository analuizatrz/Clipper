using System.Collections.Generic;
using System.Linq;

namespace Clipper.Domain.Base
{
    public class DomainValidator
    {
        private readonly List<string> errorMessages;

        private DomainValidator()
        {
            errorMessages = new List<string>();
        }

        public static DomainValidator Create()
        {
            return new DomainValidator();
        }

        public DomainValidator When(bool temErro, string mensagemDeErro)
        {
            if (temErro)
                errorMessages.Add(mensagemDeErro);

            return this;
        }

        public void ThrowExceptionIfAnyErrors()
        {
            if (errorMessages.Any())
                throw new DomainException(errorMessages);
        }
    }
}