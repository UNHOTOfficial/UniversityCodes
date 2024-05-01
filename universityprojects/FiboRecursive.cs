public class FiboRecursive
{
    public static int Fibonacci(int n)
    {
        // if the input is 0 or 1, return n
        if (n <= 1)
            return n;

        // otherwise, return the sum of the previous two numbers
        else
            return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}