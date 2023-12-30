using System;

namespace VL.Gaming.Study.Patterns
{
    public class Singleton
    {
        // 其他实例方法
        public void Sample()
        {
            Console.WriteLine("SingletonTalk:" + SingletonMessage);
        }

        private static Singleton instance;
        private static readonly object lockObject = new object();
        public string SingletonMessage { set; get; }

        private Singleton()
        {
            SingletonMessage = "SingletonWord init at " + DateTime.Now.ToString();
        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                    }
                }
                return instance;
            }
        }
    }
}
