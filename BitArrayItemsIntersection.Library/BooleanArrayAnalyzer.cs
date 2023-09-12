#define SHORTEST_ROUTE_IMPL
#undef SHORTEST_ROUTE_IMPL

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


#if SHORTEST_ROUTE_IMPL
    public BooleanElementInfo[] FindShortestRouteBetween(
        (byte Row, byte Col) routeSource, (byte Row, byte Col) routeTarget)
    {
        BooleanElementInfo sourceElement = new
        (
            row: routeSource.Row,
            column: routeSource.Col,
            charged: _Array.Content[routeSource.Row, routeSource.Col]
        );

        BooleanElementInfo targetElement = new
        (
            row: routeTarget.Row,
            column: routeTarget.Col,
            charged: _Array.Content[routeTarget.Row, routeTarget.Col]
        );

        LinkedList<BooleanElementInfo> routeNodes = new();
        routeNodes.AddFirst(new LinkedListNode<BooleanElementInfo>(sourceElement));
        routeNodes.AddLast(new LinkedListNode<BooleanElementInfo>(targetElement));

        BooleanElementInfo currentElement = sourceElement;
        while (currentElement.Equals(targetElement) is false)
        {
            RouteBuildRule nextElementSelection = ConfigureRouteBuildRule(routeSource, routeTarget);
            BooleanElementInfo nextElement = SelectNextRouteElement(currentElement, nextElementSelection, routeNodes);


            //List<BooleanElementInfo> neighbours = FindPossibleNeighbourPathElements(currentElement, startElement);
            //BooleanElementInfo nextElement = FindNextPathElement(neighbours, endElement);

            if (nextElement.Equals(targetElement))
            {
                break;
            }

            routeNodes.AddBefore(node: routeNodes.Last, value: nextElement);
            currentElement = nextElement;
        }

        return routeNodes.ToArray();
    }

    private BooleanElementInfo SelectNextRouteElement(BooleanElementInfo currentElement,
        RouteBuildRule nextElementSelection, LinkedList<BooleanElementInfo> routeNodes)
    {
        RouteBuildDirection[] suggestedDirections = nextElementSelection.GetOrderedRouteDirections();
        NeighboursInfo neighboursInfo = _Array.GetNeighboursInfoAt(currentElement.Row, currentElement.Column);
        List<RouteBuildDirection> possibleDirections = new();

        foreach (RouteBuildDirection direction in suggestedDirections)
        {
            if (direction == RouteBuildDirection.Top)
            {
                if (neighboursInfo.HasNeighbourOnTop)
                {
                    possibleDirections.Add(direction);
                    continue;
                }
            }

            if (direction == RouteBuildDirection.TopRight)
            {
                if (neighboursInfo.HasNeighbourOnTopToRight)
                {
                    possibleDirections.Add(direction);
                    continue;
                }
            }

            if (direction == RouteBuildDirection.Right)
            {
                if (neighboursInfo.HasNeighbourToRight)
                {
                    possibleDirections.Add(direction);
                    continue;
                }
            }

            if (direction == RouteBuildDirection.BottomRight)
            {
                if (neighboursInfo.HasNeighbourOnBottomToRight)
                {
                    possibleDirections.Add(direction);
                    continue;
                }
            }

            if (direction == RouteBuildDirection.Bottom)
            {
                if (neighboursInfo.HasNeighbourOnBottom)
                {
                    possibleDirections.Add(direction);
                    continue;
                }
            }

            if (direction == RouteBuildDirection.BottomLeft)
            {
                if (neighboursInfo.HasNeighbourOnBottomToLeft)
                {
                    possibleDirections.Add(direction);
                    continue;
                }
            }

            if (direction == RouteBuildDirection.Left)
            {
                if (neighboursInfo.HasNeighbourToLeft)
                {
                    possibleDirections.Add(direction);
                    continue;
                }
            }

            if (direction == RouteBuildDirection.TopLeft)
            {
                if (neighboursInfo.HasNeighbourOnTopToLeft)
                {
                    possibleDirections.Add(direction);
                    continue;
                }
            }
        }

        byte nextElementRowIndex = currentElement.Row;
        byte nextElementColIndex = currentElement.Column;
        bool nextElementCharge = currentElement.IsCharged;

        foreach (RouteBuildDirection direction in possibleDirections)
        {
            if (direction == RouteBuildDirection.Top)
            {
                nextElementRowIndex = (byte)(currentElement.Row - 1);

                nextElementCharge = _Array.Content[nextElementRowIndex, nextElementColIndex];
                if (currentElement.IsCharged == nextElementCharge)
                {
                    break;
                }
                else
                {
                    continue;
                }
            }

            if (direction == RouteBuildDirection.TopRight)
            {
                nextElementRowIndex = (byte)(currentElement.Row - 1);
                nextElementColIndex = (byte)(currentElement.Column + 1);

                nextElementCharge = _Array.Content[nextElementRowIndex, nextElementColIndex];
                if (currentElement.IsCharged == nextElementCharge)
                {
                    break;
                }
                else
                {
                    continue;
                }
            }

            if (direction == RouteBuildDirection.Right)
            {
                nextElementColIndex = (byte)(currentElement.Column + 1);

                nextElementCharge = _Array.Content[nextElementRowIndex, nextElementColIndex];
                if (currentElement.IsCharged == nextElementCharge)
                {
                    break;
                }
                else
                {
                    continue;
                }
            }

            if (direction == RouteBuildDirection.BottomRight)
            {
                nextElementRowIndex = (byte)(currentElement.Row + 1);
                nextElementColIndex = (byte)(currentElement.Column + 1);

                nextElementCharge = _Array.Content[nextElementRowIndex, nextElementColIndex];
                if (currentElement.IsCharged == nextElementCharge)
                {
                    break;
                }
                else
                {
                    continue;
                }
            }

            if (direction == RouteBuildDirection.Bottom)
            {
                nextElementRowIndex = (byte)(currentElement.Row + 1);

                nextElementCharge = _Array.Content[nextElementRowIndex, nextElementColIndex];
                if (currentElement.IsCharged == nextElementCharge)
                {
                    break;
                }
                else
                {
                    continue;
                }
            }

            if (direction == RouteBuildDirection.BottomLeft)
            {
                nextElementRowIndex = (byte)(currentElement.Row + 1);
                nextElementColIndex = (byte)(currentElement.Column - 1);

                nextElementCharge = _Array.Content[nextElementRowIndex, nextElementColIndex];
                if (currentElement.IsCharged == nextElementCharge)
                {
                    break;
                }
                else
                {
                    continue;
                }
            }

            if (direction == RouteBuildDirection.Left)
            {
                nextElementColIndex = (byte)(currentElement.Column - 1);

                nextElementCharge = _Array.Content[nextElementRowIndex, nextElementColIndex];
                if (currentElement.IsCharged == nextElementCharge)
                {
                    break;
                }
                else
                {
                    continue;
                }
            }

            if (direction == RouteBuildDirection.TopLeft)
            {
                nextElementRowIndex = (byte)(currentElement.Row - 1);
                nextElementColIndex = (byte)(currentElement.Column - 1);

                nextElementCharge = _Array.Content[nextElementRowIndex, nextElementColIndex];
                if (currentElement.IsCharged == nextElementCharge)
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        return new BooleanElementInfo(nextElementRowIndex, nextElementColIndex, nextElementCharge);
    }
#endif
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

    public RouteBuildDirection[] GetOrderedRouteDirections() => new RouteBuildDirection[]
    {
        Priority_1,
        Priority_2,
        Priority_3,
        Priority_4,
        Priority_5,
        Priority_6,
        Priority_7,
        Priority_8
    };
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
