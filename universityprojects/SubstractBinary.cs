public class SubtractBinary
{
    // main method: It takes two binary numbers as strings, converts them to decimal, subtracts them, and then converts the result back to binary.
    public static string Subtract(string binary1, string binary2)
    {
        // Convert the binary numbers to decimal
        int decimal1 = ConvertBinaryToDecimal(binary1);
        int decimal2 = ConvertBinaryToDecimal(binary2);

        // Subtract the decimal numbers
        int decimalResult = decimal1 - decimal2;

        // Convert the result to binary
        string binaryResult = ConvertDecimalToBinary(decimalResult);

        // Return the binary result
        return binaryResult;
    }

// utility method: The method is used by the main method to convert binary numbers to decimal
    public static int ConvertBinaryToDecimal(string binary)
    {
        // Check if the binary number is negative
        bool isNegative = binary[0] == '1';

        // If the binary number is negative, convert it to decimal
        if (isNegative)
        {
            // Flip the bits of the binary number (1's complement)
            string flippedBits = FlipBits(binary[1..]);

            // Convert the flipped bits to decimal and add 1 (2's complement)
            return -1 * (Convert.ToInt32(flippedBits, 2) + 1);
        }

        // If the binary number is positive, convert it to decimal
        else
        {
            // Convert the binary number to decimal
            return Convert.ToInt32(binary, 2);
        }
    }

// utility method: The method is used by the ConvertBinaryToDecimal method to flip the bits of a binary number
    public static string FlipBits(string binary)
    {
        // Flip the bits of the binary number
        return string.Concat(binary.Select(bit => bit == '0' ? '1' : '0'));
    }

// utility method: The method is used by the main method to convert decimal numbers to binary
    public static string ConvertDecimalToBinary(int decimalNumber)
    {
        // Check if the decimal number is negative
        bool isNegative = decimalNumber < 0;

        // Convert the decimal number to binary
        string binary = Convert.ToString(Math.Abs(decimalNumber), 2);

        // If the binary number is negative, add a sign bit and flip the bits (1's complement)
        if (isNegative)
        {
            return '1' + AddOne(FlipBits(binary));
        }
        else
        {
            return '0' + binary;
        }
    }

// utility method: The method is used by the ConvertDecimalToBinary method to add one to a binary number
    public static string AddOne(string binary)
    {
        // Initialize the carry to 1
        int carry = 1;

        // Convert the binary number to an array of characters
        char[] binaryArray = binary.ToCharArray();

        // Iterate over the binary number from right to left
        for (int i = binaryArray.Length - 1; i >= 0; i--)
        {
            // If the current bit is 1 and carry is 1, set the bit to 0
            if (binaryArray[i] == '1' && carry == 1)
            {
                binaryArray[i] = '0';
            }

            // If the current bit is 0 and carry is 1, set the bit to 1 and break
            else if (binaryArray[i] == '0' && carry == 1)
            {
                binaryArray[i] = '1';
                carry = 0;
            }
        }

        // Return the binary number as a string
        return new string(binaryArray);
    }
}