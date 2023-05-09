using System;

namespace Function
{
    public enum SortOrder { Ascending, Descending }

    public static class Function
    {
        public static bool IsSorted(int[] arr, SortOrder order)
        {
            if (order == SortOrder.Ascending)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] < arr[i + 1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static void Transform(int[] arr, SortOrder order)
        {
            if (IsSorted(arr, order))
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] += i;
                }
            }
        }

        public static double MultArithmeticElements(double a, double t, int n)
        {
            double result = a;
            for (int i = 1; i < n; i++)
            {
                result *= a + i * t;
            }
            return result;
        }

        public static double SumGeometricElements(double a, double t, double alim)
        {
            double sum = a;
            double term = a;
            while (term > alim)
            {
                term *= t;
                if (term > alim)
                {
                    sum += term;
                }
            }
            return sum;
        }
    }

}
