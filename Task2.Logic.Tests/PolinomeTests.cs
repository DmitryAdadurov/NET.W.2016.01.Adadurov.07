using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task2.Logic;

namespace Task2.Logic.Tests
{
    [TestFixture]
    public class PolinomeTests
    {

        static object[] TestCoefs = {
                                        new double[] { 1, 2, -3, 0, 9, -7 }
                                     };


        [Test, TestCaseSource("TestCoefs")]
        public void FillingTest(params double[] coefs)
        {
            double[] actual = new double[coefs.Length];

            Polinome p = new Polinome(coefs.Length);

            for (int i = 0; i < coefs.Length; i++)
            {
                p[i] = coefs[i];
            }

            for (int i = 0; i < coefs.Length; i++)
            {
                actual[i] = p[i];
            }

            Assert.IsTrue(coefs.SequenceEqual(coefs));

        }

        [Test, TestCaseSource("TestCoefs")]
        public void AddingTest(params double[] coefs)
        {
            Polinome p = new Polinome(coefs);

            Polinome res = p + p;

            double[] actual = new double[res.MaxNonZeroValueIndex];

            for (int i = 0; i < actual.Length; i++)
            {
                actual[i] = res[i];
            }

            double[] expected = new double[res.MaxNonZeroValueIndex];

            for (int i = 0; i < expected.Length; i++)
            {
                expected[i] = coefs[i] + coefs[i];
            }

            Assert.IsTrue(expected.SequenceEqual(actual));

        }


        [Test, TestCaseSource("TestCoefs")]
        public void MultiplicationTest(params double[] coefs)
        {
            Polinome p = new Polinome(coefs);
            
            Polinome res = p * p;

            double[] actual = new double[res.MaxNonZeroValueIndex + 1];

            for (int i = 0; i <= res.MaxNonZeroValueIndex; i++)
            {
                actual[i] = res[i];
            }

            double[] expected = new double[] { 49, -126, 81, 42, -82, 22, 27, -12, -2, 4, 1 };
            expected = expected.Reverse().ToArray();

            Assert.IsTrue(expected.SequenceEqual(actual));

        }

    }
}
