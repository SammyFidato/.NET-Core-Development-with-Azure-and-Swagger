using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myProject
{
    public class AppConfigUtil
    {

        #region Keys of App Configuration
        //To be specified only inside this class as a best practice
        public static string key1 { get; } = "Environment";
        public static string key2 { get; } = "CrunchBaseUrl";

        #endregion

    }

}
