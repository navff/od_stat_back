using System;
using OD_Stat.DataAccess;

namespace Tests.Scenarios
{
    public abstract class BaseTestScenario<T> : IDisposable
    {
        protected OdContext _context;

        protected BaseTestScenario(OdContext context)
        {
            _context = context;
        }

        public abstract T Run();

        public abstract void Dispose();
    }
}