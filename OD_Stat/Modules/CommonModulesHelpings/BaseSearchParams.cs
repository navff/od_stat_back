using System;
using Common;

namespace OD_Stat.Modules.CommonModulesHelpings
{
    public abstract class BaseSearchParams
    {
        private int _page = 1;
        private int _take = 1;

        public int Page
        {
            get => _page;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Page must be larger than '1'");
                }
            }
        }

        public int Take
        {
            get => _take;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Page must be larger than '1'");
                }
            }
        }
    }
}