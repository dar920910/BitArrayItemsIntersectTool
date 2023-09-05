using BitArrayItemsIntersection.Library;
using static System.Console;

CustomBooleanArray array = CreateUserDefinedArray(
    rows: ReadCustomDimensionLength("Input Array's Rows Dimension: "),
    columns: ReadCustomDimensionLength("Input Array's Columns Dimension: "),
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

CustomBooleanArray CreateUserDefinedArray(byte rows, byte columns,
    ConsoleKeyInfo valueSelectionKeyInfo)
{
    switch (valueSelectionKeyInfo.Key)
    {
        case ConsoleKey.R:
            return CustomBooleanArray.GenerateRandomBooleanArray(rows, columns);
        case ConsoleKey.F:
            return new CustomBooleanArray(rows, columns,
                hasChargedElements: false);
        case ConsoleKey.T:
            return new CustomBooleanArray(rows, columns,
                hasChargedElements: true);
        default:
            return new CustomBooleanArray(rows, columns);
    }
}

void PrintBooleanArray(CustomBooleanArray array)
{
    WriteLine("\nCustomBooleanArray: X = {0}, Y = {1}\n",
        array.CountOfColumns, array.CountOfRows);

    for (byte row = 0; row < array.CountOfRows; row++)
    {
        for (byte column = 0; column < array.CountOfColumns; column++)
        {
            WriteLine("array[ X: {0}, Y: {1} ] = {2}",
                column, row, array.Content[row, column]);
        }

        WriteLine();
    }

    WriteLine();
}
