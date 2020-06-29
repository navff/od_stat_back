using System.Collections.Generic;

namespace Common.Config
{
    public class RootConfig
    {
        public DaDataConfig DaDataConfig { get; set; }
        public Dictionary<string, string> ConnectionStrings { get; set; }
        public AuthenticationConfig AuthenticationConfig {get; set;}
    }
}