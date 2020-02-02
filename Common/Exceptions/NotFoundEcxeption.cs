using System;

namespace Common.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(Type type, string id)
        : base($"{type.Name} with Id={id} is not found")
        { }
    }
}