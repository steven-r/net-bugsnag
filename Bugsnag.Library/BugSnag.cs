using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugsnag.Library
{
    public static class BugSnag
    {
        public static string apiKey
        {
            get;
            set;
        }

        public static bool useSSL
        {
            get;
            set;
        }

        public static void Notify(Exception ex)
        {

        }
    }
}
