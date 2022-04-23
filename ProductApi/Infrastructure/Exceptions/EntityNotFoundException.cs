using System;

namespace ProductApi.Infrastructure.Exceptions
{
    public class EntityNotFoundException : ArgumentNullException
    {
        public EntityNotFoundException(string message)
            : base(message)
        {
        }
    }
}
