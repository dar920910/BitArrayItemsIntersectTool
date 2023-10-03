//-----------------------------------------------------------------------
// <copyright file="DataStore.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

using BitArrayItemsIntersection.Library;

public static class DataStore
{
    public static CustomBooleanArray CurrentArray { get; private set; }

    public static (byte Row, byte Column) LastElement { get; private set; }

    public static byte CurrentElementRow { get; private set; }

    public static byte CurrentElementCol { get; private set; }

    public static List<BooleanElementInfo> NeighbourElements { get; private set; }

    public static (byte Row, byte Col) RouteElement_A { get; private set; }

    public static (byte Row, byte Col) RouteElement_B { get; private set; }

    public static BooleanElementInfo[] RouteElements { get; private set; }

    public static void InitializeCustomArray(byte rows, byte cols)
    {
        CurrentArray = CustomBooleanArray.GenerateRandomBooleanArray(rows, cols);

        LastElement = (
            Row: Convert.ToByte(CurrentArray.CountOfRows - 1),
            Column: Convert.ToByte(CurrentArray.CountOfColumns - 1));
    }

    public static void InitializeNeighbourElements(byte elementRow, byte elementCol)
    {
        CurrentElementRow = elementRow;
        CurrentElementCol = elementCol;

        NeighbourElements = CurrentArray.FindNeighbourElementsAt(
            elementRow: CurrentElementRow, elementColumn: CurrentElementCol);
    }

    public static void InitializeShortestRouteBetweenElements(
        (byte Row, byte Col) element_A, (byte Row, byte Col) element_B)
    {
        RouteElement_A = element_A;
        RouteElement_B = element_B;

        BooleanArrayAnalyzer analyzer = new (CurrentArray);

        if (analyzer.CanTryToMakeRouteBetweenArrayElements(
            from: RouteElement_A, to: RouteElement_B))
        {
            RouteElements = analyzer.FindShortestRouteBetween(
                routeSource: RouteElement_A,
                routeTarget: RouteElement_B);
        }
        else
        {
            RouteElements = Array.Empty<BooleanElementInfo>();
        }
    }
}
