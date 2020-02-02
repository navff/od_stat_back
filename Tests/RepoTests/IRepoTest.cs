using System.Threading.Tasks;

namespace Tests.RepoTests
{
    public interface IRepoTest
    {
        public Task GetById_Ok_Test();
        public Task GetById_WrongId_Test();
        public Task Search_Ok_Test();
        public Task Search_NotFound_Test();
        public Task Update_Ok_Test();
        public Task Delete_Ok_Test();
    }
}