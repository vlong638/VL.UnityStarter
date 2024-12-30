using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.Gaming.Unity.Tools
{
    public class VLDebug
    {
        public static bool IsDebug = true;
        public static void DelegateDebug(Action action)
        {
            if (IsDebug)
            {
                action();
            }
        }
    }
}
