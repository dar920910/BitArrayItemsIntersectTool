namespace BitArrayItemsIntersection.Library;

public class CustomBooleanArray
{
    public bool[,] Content { get; }

    public readonly byte CountOfRows;
    public readonly byte CountOfColumns;

    public CustomBooleanArray(byte rowsDimension, byte columnsDimension,
        bool hasChargedElements = false)
    {
        Content = CreateDefaultBooleanArray(
            rowsDimension, columnsDimension, hasChargedElements);

        CountOfRows = Convert.ToByte(Content.GetLength(dimension: 0));
        CountOfColumns = Convert.ToByte(Content.GetLength(dimension: 1));
    }

    public CustomBooleanArray(bool[,] array)
    {
        Content = array;
        CountOfRows = Convert.ToByte(Content.GetLength(dimension: 0));
        CountOfColumns = Convert.ToByte(Content.GetLength(dimension: 1));
    }

    public CustomBooleanArray(int[,] array)
    {
        Content = ConvertToBooleanArray(array);
        CountOfRows = Convert.ToByte(Content.GetLength(dimension: 0));
        CountOfColumns = Convert.ToByte(Content.GetLength(dimension: 1));
    }


    public List<BooleanElementInfo> FindAllChargedElements()
    {
        var elements = new List<BooleanElementInfo>();

        for (byte row = 0; row < CountOfRows; row++)
        {
            for (byte column = 0; column < CountOfColumns; column++)
            {
                if (Content[row, column] is true)
                {
                    elements.Add(new BooleanElementInfo(row, column, charged: true));
                }
            }
        }

        return elements;
    }

    public List<BooleanElementInfo> FindAllNonChargedElements()
    {
        var elements = new List<BooleanElementInfo>();

        for (byte row = 0; row < CountOfRows; row++)
        {
            for (byte column = 0; column < CountOfColumns; column++)
            {
                if (Content[row, column] is false)
                {
                    elements.Add(new BooleanElementInfo(row, column));
                }
            }
        }

        return elements;
    }


    /// <summary>
    /// Generate a two-dimensional array with the specified dimensions.
    /// </summary>
    /// <param name="rows">Custom count of rows-elements</param>
    /// <param name="columns">Custom count of columns-elements</param>
    /// <param name="elementPlaceholderValue">Custom value of an element</param>
    /// <returns>Two-dimensional array with the specified dimensions.</returns>
    private bool[,] CreateDefaultBooleanArray(byte rows, byte columns, bool charged)
    {
        var array = new bool[rows, columns];

        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                array[row, column] = charged;
            }
        }

        return array;
    }

    /// <summary>
    /// Convert an integer array to matching boolean array,
    /// where positive elements are processed as True and
    /// other elements are False (negative and 0).
    /// </summary>
    /// <param name="array">Array filled by integer values</param>
    /// <returns>Matching two-dimensional boolean array</returns>
    private bool[,] ConvertToBooleanArray(int[,] integers)
    {
        int countOfRows = integers.GetLength(dimension: 0);
        int countOfColumns = integers.GetLength(dimension: 1);

        bool[,] array = new bool[countOfRows, countOfColumns];

        for (int row = 0; row < countOfRows; row++)
        {
            for (int column = 0; column < countOfColumns; column++)
            {
                array[row, column] = integers[row, column] > 0;
            }
        }

        return array;
    }

    public static CustomBooleanArray GenerateRandomBooleanArray(byte rows, byte columns)
    {
        var array = new bool[rows, columns];

        for (byte row = 0; row < rows; row++)
        {
            for (byte column = 0; column < columns; column++)
            {
                array[row, column] = GenerateRandomBooleanValue();
            }
        }

        return new CustomBooleanArray(array);
    }

    private static bool GenerateRandomBooleanValue()
    {
        return Random.Shared.Next(
            minValue: int.MinValue,
            maxValue: int.MaxValue
        ) >= 0;
    }
}

public struct BooleanElementInfo
{
    public readonly byte Row;
    public readonly byte Column;
    public readonly bool IsCharged;

    public BooleanElementInfo(byte row, byte column, 
        bool charged = false)
    {
        Row = row;
        Column = column;
        IsCharged = charged;
    }
}
