﻿namespace Backend.Core.Variables
{
    public static class ServerPathEnviorement
    {
        private static string LocalURL = $@"‪./../../../../_server_";
        private static string LiveURL = $@"";

        public static string Base()
        {
#if DEBUG
            return LocalURL;
#else
            return LiveURL;
#endif
        }
    }
}
