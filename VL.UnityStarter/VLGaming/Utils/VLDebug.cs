using System;

namespace Assets.Scenes.VLGamingStudy
{
    class VLDebug
    {
        public static bool IsDebug = true;
        /// <summary>
        /// ��ʾ��ͼ����
        /// </summary>
        /// <param name="go"></param>
        /// <param name="newPosition"></param>
        public static void DelegateDebug(Action action)
        {
            if (IsDebug)
            {
                action();
            }
        }
    }
}