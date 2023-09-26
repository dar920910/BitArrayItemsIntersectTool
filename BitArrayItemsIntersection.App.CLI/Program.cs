//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using BitArrayItemsIntersection.Library;
using static System.Console;

CustomBooleanArray array = CreateUserDefinedArray(
    rows: ReadCustomDimensionLength("Input Array's Rows Dimension: "),
    columns: ReadCustomDimensionLength("Input Array's Columns Dimension: "),
    valueSelectionKeyInfo: ReadCustomValueSelectionKey());

PrintBooleanArray(array);

ApplyUserActionToCustomArray(
    actionSelectionKeyInfo: ReadUserActionSelectionKey(),
    array: array);

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
            WriteLine("ERROR! Please input an integer from {0} to {1}", byte.MinValue, byte.MaxValue);
        }
    }
    while (true);
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
        ConsoleKey.T,
    };

    return ReadSelectionKey(possibleKeys);
}

ConsoleKeyInfo ReadSelectionKey(ConsoleKey[] availableKeys)
{
    do
    {
        Write("Press a selection key (either UPPER of lower case): ");
        ConsoleKeyInfo userKey = ReadKey();
        WriteLine();

        if (availableKeys.Contains(userKey.Key))
        {
            return userKey;
        }
        else
        {
            WriteLine("ERROR! Please select a possible key!");
        }
    }
    while (true);
}

CustomBooleanArray CreateUserDefinedArray(byte rows, byte columns, ConsoleKeyInfo valueSelectionKeyInfo)
{
    switch (valueSelectionKeyInfo.Key)
    {
        case ConsoleKey.R:
            return CustomBooleanArray.GenerateRandomBooleanArray(rows, columns);
        case ConsoleKey.F:
            return new CustomBooleanArray(rows, columns, hasChargedElements: false);
        case ConsoleKey.T:
            return new CustomBooleanArray(rows, columns, hasChargedElements: true);
        default:
            return new CustomBooleanArray(rows, columns);
    }
}

void PrintBooleanArray(CustomBooleanArray array)
{
    WriteLine("\nCustomBooleanArray: X = {0}, Y = {1}\n", array.CountOfColumns, array.CountOfRows);

    for (byte row = 0; row < array.CountOfRows; row++)
    {
        for (byte column = 0; column < array.CountOfColumns; column++)
        {
            WriteLine("array[ X: {0}, Y: {1} ] = {2}", column, row, array.Content[row, column]);
        }

        WriteLine();
    }

    WriteLine();
}

ConsoleKeyInfo ReadUserActionSelectionKey()
{
    WriteLine("Now select an action to investigate elements of the array:");
    WriteLine("-) '1' - Find available intersections for an element");
    WriteLine("-) '2' - Find the shortest route between two elements");

    ConsoleKey[] possibleKeys = new[]
    {
        ConsoleKey.D1,
        ConsoleKey.D2,
    };

    return ReadSelectionKey(possibleKeys);
}

void ApplyUserActionToCustomArray(ConsoleKeyInfo actionSelectionKeyInfo, CustomBooleanArray array)
{
    switch (actionSelectionKeyInfo.Key)
    {
        case ConsoleKey.D1:
            GetCustomElementNeighbours(array);
            break;
        case ConsoleKey.D2:
            GetShortestRouteBetweenElements(array);
            break;
        default:
            WriteLine("Default Action");
            break;
    }
}

void GetCustomElementNeighbours(CustomBooleanArray array)
{
    WriteLine("\n*** Find All Neighbours for a Custom Element ***\n");

    byte elementRowIndex = ReadElementIndex(
        promptMessage: "Input Custom Element's Row Index: ",
        maxAvailableIndex: Convert.ToByte(array.CountOfRows - 1));

    byte elementColIndex = ReadElementIndex(
        promptMessage: "Input Custom Element's Col Index: ",
        maxAvailableIndex: Convert.ToByte(array.CountOfColumns - 1));

    WriteLine("\nRESULTS:\n");

    List<BooleanElementInfo> neighbours = array.FindNeighbourElementsAt(
        elementRowIndex, elementColIndex);

    foreach (BooleanElementInfo element in neighbours)
    {
        WriteLine($"Neighbour Element: [ Row: {element.Row}, Column: {element.Column} ]");
    }

    WriteLine();
}

void GetShortestRouteBetweenElements(CustomBooleanArray array)
{
    WriteLine("\n*** Find the Shortest Route between Two Custom Elements ***\n");

    byte maxRowIndex = Convert.ToByte(array.CountOfRows - 1);
    byte maxColIndex = Convert.ToByte(array.CountOfColumns - 1);

    WriteLine("Initialize Coordinates of an Element A:");
    byte elementRowIndex_A = ReadElementIndex("Input 'Element A' Row Index: ", maxRowIndex);
    byte elementColIndex_A = ReadElementIndex("Input 'Element A' Col Index: ", maxColIndex);
    var element_A = (elementRowIndex_A, elementColIndex_A);

    WriteLine("Initialize Coordinates of an Element B:");
    byte elementRowIndex_B = ReadElementIndex("Input 'Element B' Row Index: ", maxRowIndex);
    byte elementColIndex_B = ReadElementIndex("Input 'Element B' Col Index: ", maxColIndex);
    var element_B = (elementRowIndex_B, elementColIndex_B);

    WriteLine("\nRESULTS:\n");

    BooleanArrayAnalyzer analyzer = new (array);

    if (analyzer.CanTryToMakeRouteBetweenArrayElements(from: element_A, to: element_B))
    {
        BooleanElementInfo[] routeNodes = analyzer.FindShortestRouteBetween(
            routeSource: element_A, routeTarget: element_B);

        for (byte index = 0; index < routeNodes.Length; index++)
        {
            BooleanElementInfo node = routeNodes[index];
            WriteLine($"Node # {index}: [ Row: {node.Row}, Column: {node.Column} ]");
        }
    }
    else
    {
        WriteLine("ERROR: Cannot build a route between elements A and B !");
    }

    WriteLine();
}

byte ReadElementIndex(string promptMessage, byte maxAvailableIndex)
{
    do
    {
        Write(promptMessage);
        string userInput = ReadLine();

        if (byte.TryParse(userInput, out byte value))
        {
            if (value <= maxAvailableIndex)
            {
                return value;
            }
        }
        else
        {
            WriteLine("ERROR! Please input an integer from {0} to {1}", byte.MinValue, maxAvailableIndex);
        }
    }
    while (true);
}
