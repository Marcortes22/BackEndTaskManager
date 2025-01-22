using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils
{
    public static class StringFunctions
    {
        public static (string provider, string sub) SplitAuth0Indentity(string SubProvider)
        {
            var SubProviderArray = SubProvider.Split("|");

            return (SubProviderArray[0], SubProviderArray[1]);
        }

        public static string GetUserSub(string SubProvider)
        {
            var sub = SubProvider.Split("|")[1];

            return sub;
        }
    }
}
