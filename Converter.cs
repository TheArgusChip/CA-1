﻿using DeleteConsole;

static class Converter
{
    public static string ToEightBitBinary(this int source)
    {

        var binaryNumber = ToBinary(source);
        var length = binaryNumber.Length;
        for (int i = 0; i < Constants.AmountOfBits - length; i++)
        {
            binaryNumber = binaryNumber + "0";
        }

        return binaryNumber;
    }

    private static string ToBinary(int source)
    {
        if (source < 2)
        {
            return (source % 2).ToString();
        }

        return (source % 2).ToString() + ToBinary(source / 2);
    }
}