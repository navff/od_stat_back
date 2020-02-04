using System.Threading.Tasks;
using Common;
using OD_Stat.DataAccess;

namespace OD_Stat.Modules.CommonModulesHelpings
{
    public interface ICrudRepository<T>
    {
        
        Task<T> GetById(int id);
        Task<T> Add(T country);
        Task<T> Update(T country);
        Task Delete(int Id);
    }
}