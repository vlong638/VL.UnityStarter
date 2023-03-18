using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL.UnityStarter.Random
{
    public class SeedRandom
    {
        private int[] numbers;
        private int currentIndex;

        public SeedRandom(int total, int seed)
        {
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

        private void Shuffle()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int j = UnityEngine.Random.Range(i, numbers.Length);
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
    }
}
