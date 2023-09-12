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

    public RouteBuildRule ConfigureRouteBuildRule((byte Row, byte Col) from, (byte Row, byte Col) to)
    {
        RouteBuildDirection direction = GetStraightDirectionFromSourceToTarget(from ,to);
        return new RouteBuildRule(direction);
    }
}


public record RouteBuildRule
{
    public RouteBuildDirection Priority_1 { get; set; }
    public RouteBuildDirection Priority_2 { get; set; }
    public RouteBuildDirection Priority_3 { get; set; }
    public RouteBuildDirection Priority_4 { get; set; }
    public RouteBuildDirection Priority_5 { get; set; }
    public RouteBuildDirection Priority_6 { get; set; }
    public RouteBuildDirection Priority_7 { get; set; }
    public RouteBuildDirection Priority_8 { get; set; }

    public RouteBuildRule()
    {
        Priority_1 = RouteBuildDirection.None;
        Priority_2 = RouteBuildDirection.None;
        Priority_3 = RouteBuildDirection.None;
        Priority_4 = RouteBuildDirection.None;
        Priority_5 = RouteBuildDirection.None;
        Priority_6 = RouteBuildDirection.None;
        Priority_7 = RouteBuildDirection.None;
        Priority_8 = RouteBuildDirection.None;
    }
    public RouteBuildRule(RouteBuildDirection straightFromSourceToTarget)
    {
        switch (straightFromSourceToTarget)
        {
            case RouteBuildDirection.Top:
                Priority_1 = RouteBuildDirection.Top;
                Priority_2 = RouteBuildDirection.TopRight;
                Priority_3 = RouteBuildDirection.TopLeft;
                Priority_4 = RouteBuildDirection.Right;
                Priority_5 = RouteBuildDirection.Left;
                Priority_6 = RouteBuildDirection.Bottom;
                Priority_7 = RouteBuildDirection.BottomRight;
                Priority_8 = RouteBuildDirection.BottomLeft;
                break;
            case RouteBuildDirection.TopRight:
                Priority_1 = RouteBuildDirection.TopRight;
                Priority_2 = RouteBuildDirection.Right;
                Priority_3 = RouteBuildDirection.Top;
                Priority_4 = RouteBuildDirection.BottomRight;
                Priority_5 = RouteBuildDirection.TopLeft;
                Priority_6 = RouteBuildDirection.Left;
                Priority_7 = RouteBuildDirection.Bottom;
                Priority_8 = RouteBuildDirection.BottomLeft;
                break;
            case RouteBuildDirection.Right:
                Priority_1 = RouteBuildDirection.Right;
                Priority_2 = RouteBuildDirection.BottomRight;
                Priority_3 = RouteBuildDirection.TopRight;
                Priority_4 = RouteBuildDirection.Bottom;
                Priority_5 = RouteBuildDirection.Top;
                Priority_6 = RouteBuildDirection.Left;
                Priority_7 = RouteBuildDirection.BottomLeft;
                Priority_8 = RouteBuildDirection.TopLeft;
                break;
            case RouteBuildDirection.BottomRight:
                Priority_1 = RouteBuildDirection.BottomRight;
                Priority_2 = RouteBuildDirection.Right;
                Priority_3 = RouteBuildDirection.Bottom;
                Priority_4 = RouteBuildDirection.TopRight;
                Priority_5 = RouteBuildDirection.BottomLeft;
                Priority_6 = RouteBuildDirection.Left;
                Priority_7 = RouteBuildDirection.Top;
                Priority_8 = RouteBuildDirection.TopLeft;
                break;
            case RouteBuildDirection.Bottom:
                Priority_1 = RouteBuildDirection.Bottom;
                Priority_2 = RouteBuildDirection.BottomRight;
                Priority_3 = RouteBuildDirection.BottomLeft;
                Priority_4 = RouteBuildDirection.Right;
                Priority_5 = RouteBuildDirection.Left;
                Priority_6 = RouteBuildDirection.Top;
                Priority_7 = RouteBuildDirection.TopRight;
                Priority_8 = RouteBuildDirection.TopLeft;
                break;
            case RouteBuildDirection.BottomLeft:
                Priority_1 = RouteBuildDirection.BottomLeft;
                Priority_2 = RouteBuildDirection.Left;
                Priority_3 = RouteBuildDirection.Bottom;
                Priority_4 = RouteBuildDirection.TopLeft;
                Priority_5 = RouteBuildDirection.BottomRight;
                Priority_6 = RouteBuildDirection.TopLeft;
                Priority_7 = RouteBuildDirection.Top;
                Priority_8 = RouteBuildDirection.TopRight;
                break;
            case RouteBuildDirection.Left:
                Priority_1 = RouteBuildDirection.Left;
                Priority_2 = RouteBuildDirection.BottomLeft;
                Priority_3 = RouteBuildDirection.TopLeft;
                Priority_4 = RouteBuildDirection.Bottom;
                Priority_5 = RouteBuildDirection.Top;
                Priority_6 = RouteBuildDirection.Right;
                Priority_7 = RouteBuildDirection.BottomRight;
                Priority_8 = RouteBuildDirection.TopRight;
                break;
            case RouteBuildDirection.TopLeft:
                Priority_1 = RouteBuildDirection.TopLeft;
                Priority_2 = RouteBuildDirection.Left;
                Priority_3 = RouteBuildDirection.Top;
                Priority_4 = RouteBuildDirection.TopRight;
                Priority_5 = RouteBuildDirection.BottomLeft;
                Priority_6 = RouteBuildDirection.Right;
                Priority_7 = RouteBuildDirection.Bottom;
                Priority_8 = RouteBuildDirection.BottomRight;
                break;
            default:
                Priority_1 = RouteBuildDirection.None;
                Priority_2 = RouteBuildDirection.None;
                Priority_3 = RouteBuildDirection.None;
                Priority_4 = RouteBuildDirection.None;
                Priority_5 = RouteBuildDirection.None;
                Priority_6 = RouteBuildDirection.None;
                Priority_7 = RouteBuildDirection.None;
                Priority_8 = RouteBuildDirection.None;
                break;
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
