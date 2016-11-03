using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Logic
{
    public class Polinome
    {
        private const int INITIAL_SIZE = 16;

        private double[] coeffs;


        public Polinome()
        {
            coeffs = new double[INITIAL_SIZE];
        }


        public Polinome(int initialSize)
        {
            if (initialSize > 0)
            {
                coeffs = new double[initialSize];
            }
            else
            {
                coeffs = new double[INITIAL_SIZE];
            }
        }



        public Polinome(params double[] coefficients)
        {
            coeffs = new double[coefficients.Length];

            for (int i = 0; i < coefficients.Length; i++)
            {
                coeffs[i] = coefficients[i];
            }

            MaxNonZeroValueIndex = coeffs.Length;
        }




        public int MaxNonZeroValueIndex { get; private set; }








        public double this[int index]
        {
            get
            {
                if (index >= 0)
                {
                    if (index > MaxNonZeroValueIndex)
                    {
                        return 0;
                    }
                    else
                    {
                        return coeffs[index];
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }

            set
            {
                if (index >= 0)
                {
                    coeffs[index] = value;
                    if (index > MaxNonZeroValueIndex)
                    {
                        MaxNonZeroValueIndex = index;
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public static Polinome operator +(Polinome first, Polinome second)
        {
            int power;

            if (first.MaxNonZeroValueIndex > second.MaxNonZeroValueIndex)
                power = first.MaxNonZeroValueIndex;
            else
                power = second.MaxNonZeroValueIndex;

            Polinome result = new Polinome(power);

            for (int i = 0; i < power; i++)
            {
                result[i] = first[i] + second[i];
            }

            return result;
        }

        public static Polinome operator -(Polinome first, Polinome second)
        {
            int power;

            if (first.MaxNonZeroValueIndex > second.MaxNonZeroValueIndex)
                power = first.MaxNonZeroValueIndex;
            else
                power = second.MaxNonZeroValueIndex;

            Polinome result = new Polinome(power);

            for (int i = 0; i < power; i++)
            {
                result[i] = first[i] - second[i];
            }

            return result;
        }

        public static Polinome operator *(Polinome first, int multiplier)
        {
            int power;

            power = first.MaxNonZeroValueIndex;

            Polinome result = new Polinome(power);

            for (int i = 0; i < power; i++)
            {
                result[i] = first[i] * multiplier;
            }

            return result;
        }

        public static Polinome operator *(Polinome first, Polinome second)
        {
            int power;

            if (first.MaxNonZeroValueIndex > second.MaxNonZeroValueIndex)
                power = first.MaxNonZeroValueIndex;
            else
                power = second.MaxNonZeroValueIndex;

            Polinome result = new Polinome(power + power);

            for (int i = 0; i < power; i++)
            {
                for (int j = 0, pos = i; j < power; j++, pos++)
                {
                    result[pos] = result[pos] +  (first[i] * second[j]);

                    if (result.MaxNonZeroValueIndex < pos) result.MaxNonZeroValueIndex = pos;
                }
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(8 * MaxNonZeroValueIndex);

            sb.Append(this[0].ToString());

            for (int i = 1; i <= MaxNonZeroValueIndex; i++)
            {
                sb.Append(this[i].ToString("+00;-00;+00") + "x^" + i.ToString());
            }
            return sb.ToString();
        }

    }
}
