using System;

namespace Common.Exceptions
{
    public class EntityNotFoundException<T> : Exception
    {
        public EntityNotFoundException(string id)
            : base($"{typeof(T).Name} with Id={id} was not found")
        {
        }
    }
}