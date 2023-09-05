using BitArrayItemsIntersection.Library;
using static System.Console;

CustomBooleanArray array = CreateUserDefinedArray(
    dimension_X: ReadCustomDimensionLength("Input Array's Dimension X: "),
    dimension_Y: ReadCustomDimensionLength("Input Array's Dimension Y: "),
    valueSelectionKeyInfo: ReadCustomValueSelectionKey()
);

PrintBooleanArray(array);


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

ConsoleKeyInfo ReadCustomValueSelectionKey()
{
    WriteLine("Select a type of a custom value to fill elements of a new array:");
    WriteLine("-) 'D' - Default fill elements of a new array");
    WriteLine("-) 'R' - Random filling elements of a new array");
    WriteLine("-) 'F' - Use 'False' value to fill all elements of a new array");
    WriteLine("-) 'T' - Use 'True' value to fill all elements of a new array");

    ConsoleKey[] possibleKeys = new[]
    {
        ConsoleKey.D,
        ConsoleKey.R,
        ConsoleKey.F,
        ConsoleKey.T
    };

    do
    {
        Write("Press a selection key (either UPPER of lower case): ");
        ConsoleKeyInfo userKey = ReadKey();
        WriteLine();

        if (possibleKeys.Contains(userKey.Key))
        {
            return userKey;
        }
        else
        {
            WriteLine("ERROR! Please select a possible key!");
        }

    } while (true);
}

CustomBooleanArray CreateUserDefinedArray(byte dimension_X, byte dimension_Y,
    ConsoleKeyInfo valueSelectionKeyInfo)
{
    switch (valueSelectionKeyInfo.Key)
    {
        case ConsoleKey.R:
            return CustomBooleanArray.GenerateRandomBooleanArray(dimension_X, dimension_Y);
        case ConsoleKey.F:
            return new CustomBooleanArray(dimension_X, dimension_Y, false);
        case ConsoleKey.T:
            return new CustomBooleanArray(dimension_X, dimension_Y, true);
        default:
            return new CustomBooleanArray(dimension_X, dimension_Y);
    }
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
