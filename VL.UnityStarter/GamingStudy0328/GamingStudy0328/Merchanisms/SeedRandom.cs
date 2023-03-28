using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.GamingStudy0328
{
    public class SeedRandom : ICloneableObject<SeedRandom>
    {
        private int[] numbers;
        private int currentIndex;

        public int Total { get; }
        public int Seed { get; }

        public SeedRandom(int total, int seed)
        {
            Total = total;
            Seed = seed;
            numbers = new int[total];
            for (int i = 0; i < seed; i++)
            {
                numbers[i] = 1;
            }
            for (int i = seed; i < total; i++)
            {
                numbers[i] = 0;
            }
            Shuffle();
        }

        /// <summary>
        /// 乱序
        /// </summary>
        private void Shuffle()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int j = Random.Range(i, numbers.Length);
                int temp = numbers[i];
                numbers[i] = numbers[j];
                numbers[j] = temp;
            }
            currentIndex = 0;
        }

        public int GetNext()
        {
            if (currentIndex == numbers.Length)
            {
                Shuffle();
            }
            return numbers[currentIndex++];
        }

        public SeedRandom Clone()
        {
            return new SeedRandom(Total, Seed);
        }
    }
}
