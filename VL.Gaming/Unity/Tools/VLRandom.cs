using System;

namespace VL.Gaming.Unity.Tools
{
    public class VLRandom
    {
        static Random _random;
        static object _object = new object();
        public static Random Random
        {
            get
            {
                if (_random == null)
                {
                    lock (_object)
                    {
                        if (_random == null)
                        {
                            _random = new Random();
                        }
                    }
                }
                return _random;
            }
        }
    }
}
