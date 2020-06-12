using System;

namespace ABC
{
    class Program
    {
        static void Main(string[] args)
        {
            // ABC problem 
            // https://open.kattis.com/problems/abc
            // order three numbers according to orderof three chars
            // (A min) (B mid) (C max)


            var numbers = EnterNumbers();

            var threeChar = EnterThreeChars();

            var result = OrderedArray(threeChar, OrderInts(numbers));

            PrintIntArray(result);
        }
        private static void PrintIntArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
        private static int[] OrderedArray(char[] charArr, int[] nums)
        {
            var maxNum = nums[0];
            var minNum = nums[1];
            var middleNum = nums[2];

            int[] result = new int[3];

            for (int i = 0; i < charArr.Length; i++)
            {
                if (charArr[i] == 'A')
                    result[i] = minNum;
                if (charArr[i] == 'B')
                    result[i] = middleNum;
                if (charArr[i] == 'C')
                    result[i] = maxNum;
                else
                    continue;
            }
            return result;
        }

        private static int[] OrderInts(int[] nums)
        {
            // Max - Min - Middle
            int max = Math.Max(nums[0], Math.Max(nums[1], nums[2]));
            int min = Math.Min(nums[0], Math.Min(nums[1], nums[2]));
            int mid = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != max && nums[i] != min)
                    mid = nums[i];
                if (max == min)
                    mid = max;
            }
            int[] res = new int[3] { max, min, mid };
            return res;
        }
        private static void Swap(int a, int b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        private static char[] EnterThreeChars()
        {
            string str = " ";
            char[] charArr = new char[3] { ' ', ' ', ' ' };
            try
            {
                str = Console.ReadLine();
                if (str != "ABC" && str != "ACB" && str != "BAC" && str != "CBA"
                    && str != "BCA" && str != "CAB")
                    throw new ArgumentException();
                charArr = str.ToCharArray();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.GetType().ToString());
                return EnterThreeChars();
            }
            return charArr;
        }
        private static int[] EnterNumbers()
        {
            string str = " ";
            str = Console.ReadLine();
            string[] strArr = new string[3] { " ", " ", " " };
            int[] nums = new int[3] { 0, 0, 0 };
            try
            {
                strArr = str.Split(' ', 3);
                if (strArr.Length != 3)
                    throw new ArgumentException();
                for (int i = 0; i < strArr.Length; i++)
                {
                    nums[i] = int.Parse(strArr[i]);
                    if (nums[i] < 0 || nums[i] > 100)
                        throw new ArgumentException();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().ToString());
                return EnterNumbers();
            }
            return nums;
        }
    }
}
