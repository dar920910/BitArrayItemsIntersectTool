namespace BitArrayItemsIntersection.Library;

public class CustomBooleanArray
{
    public bool[,] Content { get; }

    public CustomBooleanArray(byte dimension_X, byte dimension_Y)
    {
        Content = CreateDefaultBooleanArray(dimension_X, dimension_Y);
    }

    private bool[,] CreateDefaultBooleanArray(byte dimension_X, byte dimension_Y)
    {
        var array = new bool[dimension_X, dimension_Y];

        int arrLength_X = array.GetLength(0);
        int arrLength_Y = array.GetLength(1);

        for (int index_X = 0; index_X < arrLength_X; index_X++)
        {
            for (int index_Y = 0; index_Y < arrLength_Y; index_Y++)
            {
                array[index_X, index_Y] = default;
            }
        }

        return array;
    }
}
