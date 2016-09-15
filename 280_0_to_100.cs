using System;
using System.Linq;

namespace ProgrammerDaily
{
    internal static class _0To100
    {
        internal static void Check(int[] sequence)
        {
            // Assuming we have all the five "fingers"
            // But we don't care about the thumbs

            // "Ones" can be followed by "zeros" but not vice-versa!
            for (int i = 2; i < 5; i++)
                if (sequence[i] > sequence[i-1])
                    throw new ArgumentException();
        }

        internal static int Decode(int[] sequence)
        {
            // Assuming that the input is correct

            // If we have thumbs up that means passed four and overflow
            var ret = sequence[0] * 5;

            // Because the input is correct the count of "ones" will make up the number
            ret += sequence.Skip(1).Count(i => i == 1);

            return ret;
        }

        internal static void Main()
        {
            try
            {
                var sequence = new int[] { 0, 1, 1, 1, 0, 1, 1, 1, 0, 0 };
                //var sequence = new int[] { 1, 0, 1, 0, 0, 1, 0, 0, 0, 0 };
                //var sequence = new int[] { 0, 0, 1, 1, 1, 0, 1, 1, 1, 0 };
                //var sequence = new int[] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 };
                //var sequence = new int[] { 1, 1, 1, 1, 1, 1, 0, 0, 0, 1 };

                // Slicing the input into two pieces [0, 4] [5, 9]
                // The left hand is essentially the same as the right but reversed
                // We just reverse it "back"
                var leftHand = sequence.Take(5).Reverse().ToArray();
                var rightHand = sequence.Skip(5).Take(5).ToArray();

                // Checking the hands one by one
                Check(leftHand);
                Check(rightHand);

                // The value of left hand has to be multiplied by 10 because it will be the first number
                var value = Decode(leftHand) * 10 + Decode(rightHand);

                Console.WriteLine(value);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid");
            }
        }
    }
}
