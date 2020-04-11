using System.Threading.Tasks;
using AutoMapper;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using OD_Stat.Modules.Divisions;

namespace OD_Stat.Modules.CommonModulesHelpings
{
    public interface ICrudController<T_ViewModelPost, T_SearchParams>
    {
        Task<ObjectResult> Get(int id);
        Task<ObjectResult> Post(T_ViewModelPost viewModel);
        Task<ObjectResult> Put(int id, T_ViewModelPost viewModel);
        Task<ObjectResult> Delete(int id);
        Task<ObjectResult> Search(T_SearchParams searchParams);
    }
}