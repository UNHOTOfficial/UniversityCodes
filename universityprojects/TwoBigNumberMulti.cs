// problem
using System;
using System.Numerics;

public class BigNumberMultiplication
{
    private static int threshold = 1;

    public static BigInteger Multiply(BigInteger u, BigInteger v)
    {
        int n = Math.Max(u.ToString().Length, v.ToString().Length);

        if (u == 0 || v == 0)
        {
            return 0;
        }
        else if (n <= threshold)
        {
            return BigInteger.Multiply(u, v);
        }
        else
        {
            int m = n / 2;

            BigInteger x = BigInteger.Divide(u, BigInteger.Pow(10, m));
            BigInteger y = BigInteger.Remainder(u, BigInteger.Pow(10, m));
            BigInteger w = BigInteger.Divide(v, BigInteger.Pow(10, m));
            BigInteger z = BigInteger.Remainder(v, BigInteger.Pow(10, m));

            return BigInteger.Add(
                BigInteger.Add(
                    BigInteger.Multiply(BigInteger.Pow(10, 2 * m), BigInteger.Multiply(x, w)),
                    BigInteger.Multiply(BigInteger.Pow(10, m), BigInteger.Add(BigInteger.Multiply(x, z), BigInteger.Multiply(y, w)))
                ),
                BigInteger.Multiply(y, z)
            );
        }
    }
}