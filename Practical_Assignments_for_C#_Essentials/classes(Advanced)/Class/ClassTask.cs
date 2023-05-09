using System;
using System.Collections.Generic;
using System.Linq;

namespace Class
{
    public class Rectangle
    {
        private double sideA;
        private double sideB;

        public Rectangle(double a, double b)
        {
            sideA = a;
            sideB = b;
        }

        public Rectangle(double a) : this(a, 5) { }

        public Rectangle() : this(4, 3) { }

        public double GetSideA()
        {
            return sideA;
        }

        public double GetSideB()
        {
            return sideB;
        }

        public double Area()
        {
            return sideA * sideB;
        }

        public double Perimeter()
        {
            return 2 * (sideA + sideB);
        }

        public bool IsSquare()
        {
            return sideA == sideB;
        }

        public void ReplaceSides()
        {
            double temp = sideA;
            sideA = sideB;
            sideB = temp;
        }
    }

    public class ArrayRectangles
    {
        private Rectangle[] rectangle_array;

        public ArrayRectangles(int n)
        {
            rectangle_array = new Rectangle[n];
        }

        public bool AddRectangle(Rectangle rect)
        {
            for (int i = 0; i < rectangle_array.Length; i++)
            {
                if (rectangle_array[i] == null)
                {
                    rectangle_array[i] = rect;
                    return true;
                }
            }
            return false;
        }

        public int NumberMaxArea()
        {
            int index = 0;
            double maxArea = rectangle_array[0].Area();

            for (int i = 1; i < rectangle_array.Length; i++)
            {
                if (rectangle_array[i] != null && rectangle_array[i].Area() > maxArea)
                {
                    index = i;
                    maxArea = rectangle_array[i].Area();
                }
            }
            return index;
        }

        public int NumberMinPerimeter()
        {
            int index = 0;
            double minPerimeter = rectangle_array[0].Perimeter();

            for (int i = 1; i < rectangle_array.Length; i++)
            {
                if (rectangle_array[i] != null && rectangle_array[i].Perimeter() < minPerimeter)
                {
                    index = i;
                    minPerimeter = rectangle_array[i].Perimeter();
                }
            }
            return index;
        }

        public int NumberSquare()
        {
            int count = 0;
            for (int i = 0; i < rectangle_array.Length; i++)
            {
                if (rectangle_array[i] != null && rectangle_array[i].IsSquare())
                {
                    count++;
                }
            }
            return count;
        }
    }
}
