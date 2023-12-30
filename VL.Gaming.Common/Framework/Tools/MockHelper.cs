namespace VL.Gaming.Framework.Tools
{
    /// <summary>
    /// 模拟数据生成器
    /// </summary>
    public class MockHelper
    {
        public static int[] MockInts(int length,int minValue,int maxValue)
        {
            var result = new int[length];
            for (int i = 0; i < length; i++)
                result[i] = RandomHelper.Random.Next(minValue, maxValue);
            return result;
        }
    }
}
