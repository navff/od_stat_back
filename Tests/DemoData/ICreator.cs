using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests.DemoData
{
    public interface ICreator<T>
    {
        public Task<T> CreateOne();
        public Task<IEnumerable<T>> CreateMany(int count);
        
    }
}