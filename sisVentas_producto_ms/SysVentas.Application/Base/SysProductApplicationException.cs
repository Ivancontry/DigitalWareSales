using System;
using System.Runtime.Serialization;
namespace SysVentas.Application.Base
{
    public class SysProductApplicationException: Exception
    {
        public SysProductApplicationException() { }
        public SysProductApplicationException(string message) : base(message) { }
        public SysProductApplicationException(string message, Exception inner) : base(message, inner) { }
        protected SysProductApplicationException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
