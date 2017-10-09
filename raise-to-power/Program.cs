using System;
using System.Collections;

namespace raise_to_power
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RaiseToPower(7, 8));
        }

        static double RaiseToPower(double number, int power)
        {
            var bitMaskForPower = new BitArray(new int[] { power });
            var previousNumberInPower2 = number;
            var currentPowerOf2 = 1;
            var result = 1.0;
            for (var i = 0; i < bitMaskForPower.Length; i++)
            {
                if (bitMaskForPower[i])
                {
                    result *= previousNumberInPower2;
                }
                previousNumberInPower2 *= previousNumberInPower2;
                if (currentPowerOf2 + 1 > power)
                    break;
            }
            return result;
        }
    }
}
