using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SysVentas.Domain.Base
{
    public class DomainException: Exception
    {
        public DomainValidation _domainValidation { get; }
        public Dictionary<string, string> Errors { get; }
        public DomainException(DomainValidation validator)
        {
            _domainValidation = validator;
            Errors = _domainValidation.Fallos;
        }

        public DomainException(string message) : base(message)
        {
        }

        public DomainException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }
}
