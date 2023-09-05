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

    /// <summary>
    /// Generate a two-dimensional array with the specified dimensions.
    /// </summary>
    /// <param name="dimension_X">Custom count of columns-elements 
    /// (X axis locates elements from left to right)</param>
    /// <param name="dimension_Y">Custom count of rows-elements 
    /// (Y axis locates elements from top to bottom)</param>
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
}
