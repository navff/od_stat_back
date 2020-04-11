using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Mvc;
using OD_Stat.DataAccess;

namespace OD_Stat.Modules.CommonModulesHelpings
{
    public abstract class BaseCrudService<T, T_SearchResult, T_SearchParams>
    {
        protected OdContext _context;

        protected BaseCrudService(OdContext context)
        {
            _context = context;
        }

        public abstract Task<T> Get(int id);
        public abstract Task<T> Create(T entity);
        public abstract Task<T> Update(T entity);
        public abstract Task Delete(int id);
        public abstract Task<PageView<T_SearchResult>> Search(T_SearchParams searchParams);
    }
}