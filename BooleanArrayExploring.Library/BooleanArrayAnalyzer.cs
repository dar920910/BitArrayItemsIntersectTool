//-----------------------------------------------------------------------
// <copyright file="BooleanArrayAnalyzer.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1602 // EnumerationItemsMustBeDocumented

namespace BooleanArrayExploring.Library;

public class BooleanArrayAnalyzer
{
    private readonly CustomBooleanArray customArray;

    public BooleanArrayAnalyzer(CustomBooleanArray array)
    {
        this.customArray = array;
    }

    public bool CanTryToMakeRouteBetweenArrayElements(
        (byte Row, byte Col) from, (byte Row, byte Col) to)
    {
        if ((from.Row < this.customArray.CountOfRows) && (from.Col < this.customArray.CountOfColumns))
        {
            if ((to.Row < this.customArray.CountOfRows) && (to.Col < this.customArray.CountOfColumns))
            {
                bool routeSource = this.customArray.Content[from.Row, from.Col];
                bool routeTarget = this.customArray.Content[to.Row, to.Col];

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
        RouteBuildDirection direction = this.GetStraightDirectionFromSourceToTarget(from, to);
        return new RouteBuildRule(direction);
    }

    public BooleanElementInfo[] FindShortestRouteBetween(
        (byte Row, byte Col) routeSource, (byte Row, byte Col) routeTarget)
    {
        BooleanElementInfo sourceElement = new (
            row: routeSource.Row,
            column: routeSource.Col,
            charged: this.customArray.Content[routeSource.Row, routeSource.Col]);

        BooleanElementInfo targetElement = new (
            row: routeTarget.Row,
            column: routeTarget.Col,
            charged: this.customArray.Content[routeTarget.Row, routeTarget.Col]);

        LinkedList<BooleanElementInfo> routeNodes = new ();
        routeNodes.AddFirst(new LinkedListNode<BooleanElementInfo>(sourceElement));
        routeNodes.AddLast(new LinkedListNode<BooleanElementInfo>(targetElement));

        BooleanElementInfo currentElement = sourceElement;
        while (currentElement.Equals(targetElement) is false)
        {
            RouteBuildRule nextElementSelection = this.ConfigureRouteBuildRule(
                from: (currentElement.Row, currentElement.Column), to: routeTarget);

            BooleanElementInfo nextElement = this.SelectNextRouteElement(
                currentElement, nextElementSelection, routeNodes);

            if (nextElement.Equals(targetElement))
            {
                break;
            }

            routeNodes.AddBefore(node: routeNodes.Last, value: nextElement);
            currentElement = nextElement;
        }

        return routeNodes.ToArray();
    }

    private BooleanElementInfo SelectNextRouteElement(
        BooleanElementInfo currentElement, RouteBuildRule nextElementSelection, LinkedList<BooleanElementInfo> routeNodes)
    {
        RouteBuildDirection[] suggestedDirections = nextElementSelection.GetOrderedRouteDirections();
        NeighboursInfo neighboursInfo = this.customArray.GetNeighboursInfoAt(currentElement.Row, currentElement.Column);
        List<RouteBuildDirection> possibleDirections = new ();

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
                nextElementColIndex = currentElement.Column;

                nextElementCharge = this.customArray.Content[nextElementRowIndex, nextElementColIndex];

                var element = new BooleanElementInfo(nextElementRowIndex, nextElementColIndex, nextElementCharge);

                if (routeNodes.Contains(element) && (element.Equals(routeNodes.Last.Value) is false))
                {
                    continue;
                }
                else
                {
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

            if (direction == RouteBuildDirection.TopRight)
            {
                nextElementRowIndex = (byte)(currentElement.Row - 1);
                nextElementColIndex = (byte)(currentElement.Column + 1);

                nextElementCharge = this.customArray.Content[nextElementRowIndex, nextElementColIndex];

                var element = new BooleanElementInfo(nextElementRowIndex, nextElementColIndex, nextElementCharge);

                if (routeNodes.Contains(element) && (element.Equals(routeNodes.Last.Value) is false))
                {
                    continue;
                }
                else
                {
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

            if (direction == RouteBuildDirection.Right)
            {
                nextElementRowIndex = currentElement.Row;
                nextElementColIndex = (byte)(currentElement.Column + 1);

                nextElementCharge = this.customArray.Content[nextElementRowIndex, nextElementColIndex];

                var element = new BooleanElementInfo(nextElementRowIndex, nextElementColIndex, nextElementCharge);

                if (routeNodes.Contains(element) && (element.Equals(routeNodes.Last.Value) is false))
                {
                    continue;
                }
                else
                {
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

            if (direction == RouteBuildDirection.BottomRight)
            {
                nextElementRowIndex = (byte)(currentElement.Row + 1);
                nextElementColIndex = (byte)(currentElement.Column + 1);

                nextElementCharge = this.customArray.Content[nextElementRowIndex, nextElementColIndex];

                var element = new BooleanElementInfo(nextElementRowIndex, nextElementColIndex, nextElementCharge);

                if (routeNodes.Contains(element) && (element.Equals(routeNodes.Last.Value) is false))
                {
                    continue;
                }
                else
                {
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

            if (direction == RouteBuildDirection.Bottom)
            {
                nextElementRowIndex = (byte)(currentElement.Row + 1);
                nextElementColIndex = currentElement.Column;

                nextElementCharge = this.customArray.Content[nextElementRowIndex, nextElementColIndex];

                var element = new BooleanElementInfo(nextElementRowIndex, nextElementColIndex, nextElementCharge);

                if (routeNodes.Contains(element) && (element.Equals(routeNodes.Last.Value) is false))
                {
                    continue;
                }
                else
                {
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

            if (direction == RouteBuildDirection.BottomLeft)
            {
                nextElementRowIndex = (byte)(currentElement.Row + 1);
                nextElementColIndex = (byte)(currentElement.Column - 1);

                nextElementCharge = this.customArray.Content[nextElementRowIndex, nextElementColIndex];

                var element = new BooleanElementInfo(nextElementRowIndex, nextElementColIndex, nextElementCharge);

                if (routeNodes.Contains(element) && (element.Equals(routeNodes.Last.Value) is false))
                {
                    continue;
                }
                else
                {
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

            if (direction == RouteBuildDirection.Left)
            {
                nextElementRowIndex = currentElement.Row;
                nextElementColIndex = (byte)(currentElement.Column - 1);

                nextElementCharge = this.customArray.Content[nextElementRowIndex, nextElementColIndex];

                var element = new BooleanElementInfo(nextElementRowIndex, nextElementColIndex, nextElementCharge);

                if (routeNodes.Contains(element) && (element.Equals(routeNodes.Last.Value) is false))
                {
                    continue;
                }
                else
                {
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

            if (direction == RouteBuildDirection.TopLeft)
            {
                nextElementRowIndex = (byte)(currentElement.Row - 1);
                nextElementColIndex = (byte)(currentElement.Column - 1);

                nextElementCharge = this.customArray.Content[nextElementRowIndex, nextElementColIndex];

                var element = new BooleanElementInfo(nextElementRowIndex, nextElementColIndex, nextElementCharge);

                if (routeNodes.Contains(element) && (element.Equals(routeNodes.Last.Value) is false))
                {
                    continue;
                }
                else
                {
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
        }

        return new BooleanElementInfo(nextElementRowIndex, nextElementColIndex, nextElementCharge);
    }
}

public record RouteBuildRule
{
    public RouteBuildRule()
    {
        this.Priority_1 = RouteBuildDirection.None;
        this.Priority_2 = RouteBuildDirection.None;
        this.Priority_3 = RouteBuildDirection.None;
        this.Priority_4 = RouteBuildDirection.None;
        this.Priority_5 = RouteBuildDirection.None;
        this.Priority_6 = RouteBuildDirection.None;
        this.Priority_7 = RouteBuildDirection.None;
        this.Priority_8 = RouteBuildDirection.None;
    }

    public RouteBuildRule(RouteBuildDirection straightFromSourceToTarget)
    {
        switch (straightFromSourceToTarget)
        {
            case RouteBuildDirection.Top:
                this.Priority_1 = RouteBuildDirection.Top;
                this.Priority_2 = RouteBuildDirection.TopRight;
                this.Priority_3 = RouteBuildDirection.TopLeft;
                this.Priority_4 = RouteBuildDirection.Right;
                this.Priority_5 = RouteBuildDirection.Left;
                this.Priority_6 = RouteBuildDirection.Bottom;
                this.Priority_7 = RouteBuildDirection.BottomRight;
                this.Priority_8 = RouteBuildDirection.BottomLeft;
                break;
            case RouteBuildDirection.TopRight:
                this.Priority_1 = RouteBuildDirection.TopRight;
                this.Priority_2 = RouteBuildDirection.Right;
                this.Priority_3 = RouteBuildDirection.Top;
                this.Priority_4 = RouteBuildDirection.BottomRight;
                this.Priority_5 = RouteBuildDirection.TopLeft;
                this.Priority_6 = RouteBuildDirection.Left;
                this.Priority_7 = RouteBuildDirection.Bottom;
                this.Priority_8 = RouteBuildDirection.BottomLeft;
                break;
            case RouteBuildDirection.Right:
                this.Priority_1 = RouteBuildDirection.Right;
                this.Priority_2 = RouteBuildDirection.BottomRight;
                this.Priority_3 = RouteBuildDirection.TopRight;
                this.Priority_4 = RouteBuildDirection.Bottom;
                this.Priority_5 = RouteBuildDirection.Top;
                this.Priority_6 = RouteBuildDirection.Left;
                this.Priority_7 = RouteBuildDirection.BottomLeft;
                this.Priority_8 = RouteBuildDirection.TopLeft;
                break;
            case RouteBuildDirection.BottomRight:
                this.Priority_1 = RouteBuildDirection.BottomRight;
                this.Priority_2 = RouteBuildDirection.Right;
                this.Priority_3 = RouteBuildDirection.Bottom;
                this.Priority_4 = RouteBuildDirection.TopRight;
                this.Priority_5 = RouteBuildDirection.BottomLeft;
                this.Priority_6 = RouteBuildDirection.Left;
                this.Priority_7 = RouteBuildDirection.Top;
                this.Priority_8 = RouteBuildDirection.TopLeft;
                break;
            case RouteBuildDirection.Bottom:
                this.Priority_1 = RouteBuildDirection.Bottom;
                this.Priority_2 = RouteBuildDirection.BottomRight;
                this.Priority_3 = RouteBuildDirection.BottomLeft;
                this.Priority_4 = RouteBuildDirection.Right;
                this.Priority_5 = RouteBuildDirection.Left;
                this.Priority_6 = RouteBuildDirection.Top;
                this.Priority_7 = RouteBuildDirection.TopRight;
                this.Priority_8 = RouteBuildDirection.TopLeft;
                break;
            case RouteBuildDirection.BottomLeft:
                this.Priority_1 = RouteBuildDirection.BottomLeft;
                this.Priority_2 = RouteBuildDirection.Left;
                this.Priority_3 = RouteBuildDirection.Bottom;
                this.Priority_4 = RouteBuildDirection.TopLeft;
                this.Priority_5 = RouteBuildDirection.BottomRight;
                this.Priority_6 = RouteBuildDirection.TopLeft;
                this.Priority_7 = RouteBuildDirection.Top;
                this.Priority_8 = RouteBuildDirection.TopRight;
                break;
            case RouteBuildDirection.Left:
                this.Priority_1 = RouteBuildDirection.Left;
                this.Priority_2 = RouteBuildDirection.BottomLeft;
                this.Priority_3 = RouteBuildDirection.TopLeft;
                this.Priority_4 = RouteBuildDirection.Bottom;
                this.Priority_5 = RouteBuildDirection.Top;
                this.Priority_6 = RouteBuildDirection.Right;
                this.Priority_7 = RouteBuildDirection.BottomRight;
                this.Priority_8 = RouteBuildDirection.TopRight;
                break;
            case RouteBuildDirection.TopLeft:
                this.Priority_1 = RouteBuildDirection.TopLeft;
                this.Priority_2 = RouteBuildDirection.Left;
                this.Priority_3 = RouteBuildDirection.Top;
                this.Priority_4 = RouteBuildDirection.TopRight;
                this.Priority_5 = RouteBuildDirection.BottomLeft;
                this.Priority_6 = RouteBuildDirection.Right;
                this.Priority_7 = RouteBuildDirection.Bottom;
                this.Priority_8 = RouteBuildDirection.BottomRight;
                break;
            default:
                this.Priority_1 = RouteBuildDirection.None;
                this.Priority_2 = RouteBuildDirection.None;
                this.Priority_3 = RouteBuildDirection.None;
                this.Priority_4 = RouteBuildDirection.None;
                this.Priority_5 = RouteBuildDirection.None;
                this.Priority_6 = RouteBuildDirection.None;
                this.Priority_7 = RouteBuildDirection.None;
                this.Priority_8 = RouteBuildDirection.None;
                break;
        }
    }

    public RouteBuildDirection Priority_1 { get; set; }
    public RouteBuildDirection Priority_2 { get; set; }
    public RouteBuildDirection Priority_3 { get; set; }
    public RouteBuildDirection Priority_4 { get; set; }
    public RouteBuildDirection Priority_5 { get; set; }
    public RouteBuildDirection Priority_6 { get; set; }
    public RouteBuildDirection Priority_7 { get; set; }
    public RouteBuildDirection Priority_8 { get; set; }

    public RouteBuildDirection[] GetOrderedRouteDirections() => new RouteBuildDirection[]
    {
        this.Priority_1,
        this.Priority_2,
        this.Priority_3,
        this.Priority_4,
        this.Priority_5,
        this.Priority_6,
        this.Priority_7,
        this.Priority_8,
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
    TopLeft,
}
