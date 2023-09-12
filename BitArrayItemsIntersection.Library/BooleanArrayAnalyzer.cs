namespace BitArrayItemsIntersection.Library;

public class BooleanArrayAnalyzer
{
    private readonly CustomBooleanArray _Array;
    public BooleanArrayAnalyzer(CustomBooleanArray array)
    {
        _Array = array;
    }

    public bool CanTryToMakeRouteBetweenArrayElements(
        (byte Row, byte Col) from, (byte Row, byte Col) to)
    {
        if ( (from.Row < _Array.CountOfRows) && (from.Col < _Array.CountOfColumns) )
        {
            if ( (to.Row < _Array.CountOfRows) && (to.Col < _Array.CountOfColumns) )
            {
                bool routeSource = _Array.Content[from.Row, from.Col];
                bool routeTarget = _Array.Content[to.Row, to.Col];

                return routeSource == routeTarget;
            }
        }

        return false;
    }
}
