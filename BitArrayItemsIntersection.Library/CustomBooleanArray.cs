namespace BitArrayItemsIntersection.Library;

public class CustomBooleanArray
{
    public bool[,] Content { get; }

    public readonly int Length_X;
    public readonly int Length_Y;

    public CustomBooleanArray(byte dimension_X, byte dimension_Y,
        bool elementPlaceholderValue = false)
    {
        Content = CreateDefaultBooleanArray(dimension_X, dimension_Y, elementPlaceholderValue);

        Length_X = Content.GetLength(dimension: 1); // count of columns-items in the array
        Length_Y = Content.GetLength(dimension: 0); // count of rows-items in the array
    }

    public CustomBooleanArray(bool[,] array)
    {
        Content = array;
        Length_X = Content.GetLength(dimension: 1); // count of columns-items in the array
        Length_Y = Content.GetLength(dimension: 0); // count of rows-items in the array
    }

    public CustomBooleanArray(int[,] array)
    {
        Content = ConvertToBooleanArray(array);
        Length_X = Content.GetLength(dimension: 1); // count of columns-items in the array
        Length_Y = Content.GetLength(dimension: 0); // count of rows-items in the array
    }

    /// <summary>
    /// Generate a two-dimensional array with the specified dimensions.
    /// </summary>
    /// <param name="dimension_X">Custom count of columns-elements 
    /// (X axis locates elements from left to right)</param>
    /// <param name="dimension_Y">Custom count of rows-elements 
    /// (Y axis locates elements from top to bottom)</param>
    /// <param name="elementPlaceholderValue">Custom value of an element</param>
    /// <returns>Two-dimensional array with the specified dimensions.</returns>
    private bool[,] CreateDefaultBooleanArray(byte dimension_X, byte dimension_Y,
        bool elementPlaceholderValue)
    {
        var array = new bool[dimension_Y, dimension_X];

        int arrLength_X = array.GetLength(dimension: 0); // columns are on the X axis
        int arrLength_Y = array.GetLength(dimension: 1); // rows are on the Y axis

        for (int index_X = 0; index_X < arrLength_X; index_X++)
        {
            for (int index_Y = 0; index_Y < arrLength_Y; index_Y++)
            {
                array[index_X, index_Y] = elementPlaceholderValue;
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

    public static CustomBooleanArray GenerateRandomBooleanArray(byte dimension_X, byte dimension_Y)
    {
        var array = new bool[dimension_Y, dimension_X];

        int arrLength_X = array.GetLength(dimension: 0);
        int arrLength_Y = array.GetLength(dimension: 1);

        for (int index_X = 0; index_X < arrLength_X; index_X++)
        {
            for (int index_Y = 0; index_Y < arrLength_Y; index_Y++)
            {
                array[index_X, index_Y] = GenerateRandomBooleanValue();
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
