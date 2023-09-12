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

    public RouteBuildDirection GetStraightDirectionFromSourceToTarget(
        (byte Row, byte Col) from, (byte Row, byte Col) to)
    {
        if (from.Row == to.Row)
        {
            if (from.Col == to.Col)
            {
                return RouteBuildDirection.None;
            }
            else if (from.Col > to.Col)
            {
                return RouteBuildDirection.Left;
            }
            else
            {
                return RouteBuildDirection.Right;
            }
        }
        else if (from.Row > to.Row)
        {
            if (from.Col == to.Col)
            {
                return RouteBuildDirection.Top;
            }
            else if (from.Col > to.Col)
            {
                return RouteBuildDirection.TopLeft;
            }
            else
            {
                return RouteBuildDirection.TopRight;
            }
        }
        else
        {
            if (from.Col == to.Col)
            {
                return RouteBuildDirection.Bottom;
            }
            else if (from.Col > to.Col)
            {
                return RouteBuildDirection.BottomLeft;
            }
            else
            {
                return RouteBuildDirection.BottomRight;
            }
        }
    }
}



public enum RouteBuildDirection
{
    None,
    Top,
    TopRight,
    Right,
    BottomRight,
    Bottom,
    BottomLeft,
    Left,
    TopLeft
}
