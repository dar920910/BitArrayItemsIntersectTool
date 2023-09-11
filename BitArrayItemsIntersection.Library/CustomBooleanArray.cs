namespace BitArrayItemsIntersection.Library;

public class CustomBooleanArray
{
    public bool[,] Content { get; }

    public readonly byte CountOfRows;
    public readonly byte CountOfColumns;


    public CustomBooleanArray(byte rowsDimension, byte columnsDimension,
        bool hasChargedElements = false)
    {
        Content = new bool[rowsDimension, columnsDimension];

        for (int row = 0; row < rowsDimension; row++)
        {
            for (int column = 0; column < columnsDimension; column++)
            {
                Content[row, column] = hasChargedElements;
            }
        }

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

    private static bool[,] ConvertToBooleanArray(int[,] integers)
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


    public List<BooleanElementInfo> FindNeighbourElementsAt(byte elementRow, byte elementColumn)
         => GetNeighboursElementsAt(elementRow, elementColumn,
                neighboursInfo: InitializeNeighboursInfoAt(elementRow, elementColumn));

    private NeighboursInfo InitializeNeighboursInfoAt(byte elementRow, byte elementColumn)
    {
        NeighboursInfo neighbours = new();

        if (IsOnLeftArrayBound(elementColumn))
        {
            neighbours.HasNeighbourOnBottomToLeft = false;
            neighbours.HasNeighbourToLeft = false;
            neighbours.HasNeighbourOnTopToLeft = false;
        }

        if (IsOnTopArrayBound(elementRow))
        {
            neighbours.HasNeighbourOnTopToLeft = false;
            neighbours.HasNeighbourOnTop = false;
            neighbours.HasNeighbourOnTopToRight = false;
        }

        if (IsOnRightArrayBound(elementColumn, CountOfColumns))
        {
            neighbours.HasNeighbourOnTopToRight = false;
            neighbours.HasNeighbourToRight = false;
            neighbours.HasNeighbourOnBottomToRight = false;
        }

        if (IsOnBottomArrayBound(elementRow, CountOfRows))
        {
            neighbours.HasNeighbourOnBottomToRight = false;
            neighbours.HasNeighbourOnBottom = false;
            neighbours.HasNeighbourOnBottomToLeft = false;
        }

        return neighbours;
    }

    private static bool IsOnLeftArrayBound(byte columnIndex) => columnIndex == 0;
    private static bool IsOnTopArrayBound(byte rowIndex) => rowIndex == 0;
    private static bool IsOnRightArrayBound(byte columnIndex, byte columns) => columnIndex == (columns - 1);
    private static bool IsOnBottomArrayBound(byte rowIndex, byte rows) => rowIndex == (rows - 1);

    private List<BooleanElementInfo> GetNeighboursElementsAt(byte elementRow, byte elementColumn, NeighboursInfo neighboursInfo)
    {
        List<BooleanElementInfo> neighbourElements = new();

        if (neighboursInfo.HasNeighbourOnTop)
        {
            byte neighbourRow = (byte)(elementRow - 1);

            neighbourElements.Add(new BooleanElementInfo(
                row: neighbourRow, column: elementColumn,
                charged: Content[neighbourRow, elementColumn]));
        }

        if (neighboursInfo.HasNeighbourOnTopToRight)
        {
            byte neighbourRow = (byte)(elementRow - 1);
            byte neighbourColumn = (byte)(elementColumn + 1);

            neighbourElements.Add(new BooleanElementInfo(
                row: neighbourRow, column: neighbourColumn,
                charged: Content[neighbourRow, neighbourColumn]));
        }

        if (neighboursInfo.HasNeighbourToRight)
        {
            byte neighbourColumn = (byte)(elementColumn + 1);

            neighbourElements.Add(new BooleanElementInfo(
                row: elementRow, column: neighbourColumn,
                charged: Content[elementRow, neighbourColumn]));
        }

        if (neighboursInfo.HasNeighbourOnBottomToRight)
        {
            byte neighbourRow = (byte)(elementRow + 1);
            byte neighbourColumn = (byte)(elementColumn + 1);

            neighbourElements.Add(new BooleanElementInfo(
                row: neighbourRow, column: neighbourColumn,
                charged: Content[neighbourRow, neighbourColumn]));
        }

        if (neighboursInfo.HasNeighbourOnBottom)
        {
            byte neighbourRow = (byte)(elementRow + 1);

            neighbourElements.Add(new BooleanElementInfo(
                row: neighbourRow, column: elementColumn,
                charged: Content[neighbourRow, elementColumn]));
        }

        if (neighboursInfo.HasNeighbourOnBottomToLeft)
        {
            byte neighbourRow = (byte)(elementRow + 1);
            byte neighbourColumn = (byte)(elementColumn - 1);

            neighbourElements.Add(new BooleanElementInfo(
                row: neighbourRow, column: neighbourColumn,
                charged: Content[neighbourRow, neighbourColumn]));
        }

        if (neighboursInfo.HasNeighbourToLeft)
        {
            byte neighbourColumn = (byte)(elementColumn - 1);

            neighbourElements.Add(new BooleanElementInfo(
                row: elementRow, column: neighbourColumn,
                charged: Content[elementRow, neighbourColumn]));
        }

        if (neighboursInfo.HasNeighbourOnTopToLeft)
        {
            byte neighbourRow = (byte)(elementRow - 1);
            byte neighbourColumn = (byte)(elementColumn - 1);

            neighbourElements.Add(new BooleanElementInfo(
                row: neighbourRow, column: neighbourColumn,
                charged: Content[neighbourRow, neighbourColumn]));
        }

        return neighbourElements;
    }


    public List<ItemsIntersectionInfo> FindItemsIntersectionsAt(byte elementRow, byte elementColumn,
        bool hasNonChargedNodeItems = false)
    {
        List<ItemsIntersectionInfo> intersections = new();

        foreach (BooleanElementInfo neighbour in FindNeighbourElementsAt(elementRow, elementColumn))
        {
            if (hasNonChargedNodeItems)
            {
                if (neighbour.IsCharged is false)
                {
                    intersections.Add(new ItemsIntersectionInfo(
                        firstNodeItem: new BooleanElementInfo(elementRow, elementColumn),
                        lastNodeItem: new BooleanElementInfo(neighbour.Row, neighbour.Column)
                    ));
                }
            }
            else
            {
                if (neighbour.IsCharged)
                {
                    intersections.Add(new ItemsIntersectionInfo(
                        firstNodeItem: new BooleanElementInfo(
                            elementRow, elementColumn, charged: true),
                        lastNodeItem: new BooleanElementInfo(
                            neighbour.Row, neighbour.Column, charged: true)
                    ));
                }
            }
        }

        return intersections;
    }


    public BooleanElementInfo[] FindShortestPathBetweenElements(
        BooleanElementInfo startElement, BooleanElementInfo endElement)
    {
        LinkedList<BooleanElementInfo> shortestPath = new();

        shortestPath.AddFirst(new LinkedListNode<BooleanElementInfo>(startElement));
        shortestPath.AddLast(new LinkedListNode<BooleanElementInfo>(endElement));

        BooleanElementInfo currentElement = startElement;
        while (currentElement.Equals(endElement) is false)
        {
            List<BooleanElementInfo> neighbours = FindPossibleNeighbourPathElements(currentElement, startElement);
            BooleanElementInfo nextElement = FindNextPathElement(neighbours, endElement);

            if (nextElement.Equals(endElement))
            {
                break;
            }

            shortestPath.AddBefore(node: shortestPath.Last, value: nextElement);
            currentElement = nextElement;
        }

        return shortestPath.ToArray();
    }

    private List<BooleanElementInfo> FindPossibleNeighbourPathElements(BooleanElementInfo elementInfo, BooleanElementInfo pathStartElement)
    {
        List<BooleanElementInfo> possiblePathElements = new();

        List<BooleanElementInfo> neighbourElements = GetNeighboursElementsAt(
            elementRow: elementInfo.Row, elementColumn: elementInfo.Column,
            neighboursInfo: InitializeNeighboursInfoAt(elementInfo.Row, elementInfo.Column));

        foreach (BooleanElementInfo element in neighbourElements)
        {
            if (element.Equals(pathStartElement))
            {
                continue;
            }

            if (element.IsCharged)
            {
                possiblePathElements.Add(element);
            }
        }

        return possiblePathElements;
    }

    private BooleanElementInfo FindNextPathElement(List<BooleanElementInfo> possiblePathElements, BooleanElementInfo pathEndElement)
    {
        int shortestPathLengthByRow = int.MaxValue;
        int shortestPathLengthByCol = int.MaxValue;

        byte nextPathRowIndex = pathEndElement.Row;
        byte nextPathColIndex = pathEndElement.Column;

        foreach (BooleanElementInfo pathElement in possiblePathElements)
        {
            int pathLengthByRow = (pathEndElement.Row < pathElement.Row) ?
                (pathElement.Row - pathEndElement.Row) : (pathEndElement.Row - pathElement.Row);

            int pathLengthByCol = (pathEndElement.Column < pathElement.Column) ?
                (pathElement.Column - pathEndElement.Column) : (pathEndElement.Column - pathElement.Column);

            if ( (pathLengthByRow <= shortestPathLengthByRow) && (pathLengthByCol <= shortestPathLengthByCol) )
            {
                shortestPathLengthByRow = pathLengthByRow;
                shortestPathLengthByCol = pathLengthByCol;

                nextPathRowIndex = pathElement.Row;
                nextPathColIndex = pathElement.Column;
            }
        }

        return new BooleanElementInfo(nextPathRowIndex, nextPathColIndex, Content[nextPathRowIndex, nextPathColIndex]);
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

public readonly struct BooleanElementInfo
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

public struct NeighboursInfo
{
    public bool HasNeighbourOnTop { get; set; }
    public bool HasNeighbourOnTopToRight { get; set; }
    public bool HasNeighbourToRight { get; set; }
    public bool HasNeighbourOnBottomToRight { get; set; }
    public bool HasNeighbourOnBottom { get; set; }
    public bool HasNeighbourOnBottomToLeft { get; set; }
    public bool HasNeighbourToLeft { get; set; }
    public bool HasNeighbourOnTopToLeft { get; set; }

    public NeighboursInfo()
    {
        HasNeighbourOnTop = true;
        HasNeighbourOnTopToRight = true;
        HasNeighbourToRight = true;
        HasNeighbourOnBottomToRight = true;
        HasNeighbourOnBottom = true;
        HasNeighbourOnBottomToLeft = true;
        HasNeighbourToLeft = true;
        HasNeighbourOnTopToLeft = true;
    }
}

public record ItemsIntersectionInfo
{
    public readonly BooleanElementInfo FirstNode;
    public readonly BooleanElementInfo LastNode;

    public ItemsIntersectionInfo(
        BooleanElementInfo firstNodeItem,
        BooleanElementInfo lastNodeItem)
    {
        FirstNode = firstNodeItem;
        LastNode = lastNodeItem;
    }
}
