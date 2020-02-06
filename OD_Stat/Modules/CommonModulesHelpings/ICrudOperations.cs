using System.Threading.Tasks;
using Common;
using OD_Stat.DataAccess;

namespace OD_Stat.Modules.CommonModulesHelpings
{
    public interface ICrudOperations<T>
    {
        
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task<T> Update(T city);
        Task Delete(int id);
    }
}