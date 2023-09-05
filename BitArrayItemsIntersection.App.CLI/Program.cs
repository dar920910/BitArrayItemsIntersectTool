using BitArrayItemsIntersection.Library;
using static System.Console;

byte dimensionLength_X = ReadCustomDimensionLength("Input Array's Dimension X: ");
byte dimensionLength_Y = ReadCustomDimensionLength("Input Array's Dimension Y: ");

PrintBooleanArray(new CustomBooleanArray(dimensionLength_X, dimensionLength_Y));


byte ReadCustomDimensionLength(string promptMessage)
{
    do
    {
        Write(promptMessage);
        string userInput = ReadLine();

        if (byte.TryParse(userInput, out byte value))
        {
            return value;
        }
        else
        {
            WriteLine("ERROR! Please input an integer from {0} to {1}",
                byte.MinValue, byte.MaxValue);
        }

    } while (true);
}

void PrintBooleanArray(CustomBooleanArray array)
{
    WriteLine("\nCustomBooleanArray: X = {0}, Y = {1}\n",
        array.Length_X, array.Length_Y);

    for (int index_Y = 0; index_Y < array.Length_Y; index_Y++)
    {
        for (int index_X = 0; index_X < array.Length_X; index_X++)
        {
            WriteLine("array[ X: {0}, Y: {1} ] = {2}",
                index_X, index_Y, array.Content[index_Y, index_X]);
        }

        WriteLine();
    }

    WriteLine();
}
