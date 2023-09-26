//-----------------------------------------------------------------------
// <copyright file="CustomBooleanArray.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace BitArrayItemsIntersection.Library;

public class CustomBooleanArray
{
    public CustomBooleanArray(byte rowsDimension, byte columnsDimension, bool hasChargedElements = false)
    {
        this.Content = new bool[rowsDimension, columnsDimension];

        for (int row = 0; row < rowsDimension; row++)
        {
            for (int column = 0; column < columnsDimension; column++)
            {
                this.Content[row, column] = hasChargedElements;
            }
        }

        this.CountOfRows = Convert.ToByte(this.Content.GetLength(dimension: 0));
        this.CountOfColumns = Convert.ToByte(this.Content.GetLength(dimension: 1));
    }

    public CustomBooleanArray(bool[,] array)
    {
        this.Content = array;
        this.CountOfRows = Convert.ToByte(this.Content.GetLength(dimension: 0));
        this.CountOfColumns = Convert.ToByte(this.Content.GetLength(dimension: 1));
    }

    public CustomBooleanArray(int[,] array)
    {
        this.Content = ConvertToBooleanArray(array);
        this.CountOfRows = Convert.ToByte(this.Content.GetLength(dimension: 0));
        this.CountOfColumns = Convert.ToByte(this.Content.GetLength(dimension: 1));
    }

    public bool[,] Content { get; }

    public byte CountOfRows { get; }

    public byte CountOfColumns { get; }

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

    public List<ItemsIntersectionInfo> FindItemsIntersectionsAt(byte elementRow, byte elementColumn, bool hasNonChargedNodeItems = false)
    {
        List<ItemsIntersectionInfo> intersections = new ();

        foreach (BooleanElementInfo neighbour in this.FindNeighbourElementsAt(elementRow, elementColumn))
        {
            if (hasNonChargedNodeItems)
            {
                if (neighbour.IsCharged is false)
                {
                    intersections.Add(new ItemsIntersectionInfo(
                        firstNodeItem: new BooleanElementInfo(elementRow, elementColumn),
                        lastNodeItem: new BooleanElementInfo(neighbour.Row, neighbour.Column)));
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
                            neighbour.Row, neighbour.Column, charged: true)));
                }
            }
        }

        return intersections;
    }

    public List<BooleanElementInfo> FindAllChargedElements()
    {
        var elements = new List<BooleanElementInfo>();

        for (byte row = 0; row < this.CountOfRows; row++)
        {
            for (byte column = 0; column < this.CountOfColumns; column++)
            {
                if (this.Content[row, column] is true)
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

        for (byte row = 0; row < this.CountOfRows; row++)
        {
            for (byte column = 0; column < this.CountOfColumns; column++)
            {
                if (this.Content[row, column] is false)
                {
                    elements.Add(new BooleanElementInfo(row, column));
                }
            }
        }

        return elements;
    }

    public List<BooleanElementInfo> FindNeighbourElementsAt(byte elementRow, byte elementColumn)
         => this.GetNeighboursElementsAt(
                elementRow, elementColumn, neighboursInfo: this.GetNeighboursInfoAt(elementRow, elementColumn));

    public NeighboursInfo GetNeighboursInfoAt(byte elementRow, byte elementColumn)
    {
        NeighboursInfo neighbours = new ();

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

        if (IsOnRightArrayBound(elementColumn, this.CountOfColumns))
        {
            neighbours.HasNeighbourOnTopToRight = false;
            neighbours.HasNeighbourToRight = false;
            neighbours.HasNeighbourOnBottomToRight = false;
        }

        if (IsOnBottomArrayBound(elementRow, this.CountOfRows))
        {
            neighbours.HasNeighbourOnBottomToRight = false;
            neighbours.HasNeighbourOnBottom = false;
            neighbours.HasNeighbourOnBottomToLeft = false;
        }

        return neighbours;
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

    private static bool IsOnLeftArrayBound(byte columnIndex) => columnIndex == 0;

    private static bool IsOnTopArrayBound(byte rowIndex) => rowIndex == 0;

    private static bool IsOnRightArrayBound(byte columnIndex, byte columns) => columnIndex == (columns - 1);

    private static bool IsOnBottomArrayBound(byte rowIndex, byte rows) => rowIndex == (rows - 1);

    private static bool GenerateRandomBooleanValue() =>
        Random.Shared.Next(minValue: int.MinValue, maxValue: int.MaxValue) >= 0;

    private List<BooleanElementInfo> GetNeighboursElementsAt(byte elementRow, byte elementColumn, NeighboursInfo neighboursInfo)
    {
        List<BooleanElementInfo> neighbourElements = new ();

        if (neighboursInfo.HasNeighbourOnTop)
        {
            byte neighbourRow = (byte)(elementRow - 1);

            neighbourElements.Add(new BooleanElementInfo(
                row: neighbourRow, column: elementColumn, charged: this.Content[neighbourRow, elementColumn]));
        }

        if (neighboursInfo.HasNeighbourOnTopToRight)
        {
            byte neighbourRow = (byte)(elementRow - 1);
            byte neighbourColumn = (byte)(elementColumn + 1);

            neighbourElements.Add(new BooleanElementInfo(
                row: neighbourRow, column: neighbourColumn, charged: this.Content[neighbourRow, neighbourColumn]));
        }

        if (neighboursInfo.HasNeighbourToRight)
        {
            byte neighbourColumn = (byte)(elementColumn + 1);

            neighbourElements.Add(new BooleanElementInfo(
                row: elementRow, column: neighbourColumn, charged: this.Content[elementRow, neighbourColumn]));
        }

        if (neighboursInfo.HasNeighbourOnBottomToRight)
        {
            byte neighbourRow = (byte)(elementRow + 1);
            byte neighbourColumn = (byte)(elementColumn + 1);

            neighbourElements.Add(new BooleanElementInfo(
                row: neighbourRow, column: neighbourColumn, charged: this.Content[neighbourRow, neighbourColumn]));
        }

        if (neighboursInfo.HasNeighbourOnBottom)
        {
            byte neighbourRow = (byte)(elementRow + 1);

            neighbourElements.Add(new BooleanElementInfo(
                row: neighbourRow, column: elementColumn, charged: this.Content[neighbourRow, elementColumn]));
        }

        if (neighboursInfo.HasNeighbourOnBottomToLeft)
        {
            byte neighbourRow = (byte)(elementRow + 1);
            byte neighbourColumn = (byte)(elementColumn - 1);

            neighbourElements.Add(new BooleanElementInfo(
                row: neighbourRow, column: neighbourColumn, charged: this.Content[neighbourRow, neighbourColumn]));
        }

        if (neighboursInfo.HasNeighbourToLeft)
        {
            byte neighbourColumn = (byte)(elementColumn - 1);

            neighbourElements.Add(new BooleanElementInfo(
                row: elementRow, column: neighbourColumn, charged: this.Content[elementRow, neighbourColumn]));
        }

        if (neighboursInfo.HasNeighbourOnTopToLeft)
        {
            byte neighbourRow = (byte)(elementRow - 1);
            byte neighbourColumn = (byte)(elementColumn - 1);

            neighbourElements.Add(new BooleanElementInfo(
                row: neighbourRow, column: neighbourColumn, charged: this.Content[neighbourRow, neighbourColumn]));
        }

        return neighbourElements;
    }
}

public readonly struct BooleanElementInfo
{
    public readonly byte Row;
    public readonly byte Column;
    public readonly bool IsCharged;

    public BooleanElementInfo(byte row, byte column, bool charged = false)
    {
        this.Row = row;
        this.Column = column;
        this.IsCharged = charged;
    }
}

public struct NeighboursInfo
{
    public NeighboursInfo()
    {
        this.HasNeighbourOnTop = true;
        this.HasNeighbourOnTopToRight = true;
        this.HasNeighbourToRight = true;
        this.HasNeighbourOnBottomToRight = true;
        this.HasNeighbourOnBottom = true;
        this.HasNeighbourOnBottomToLeft = true;
        this.HasNeighbourToLeft = true;
        this.HasNeighbourOnTopToLeft = true;
    }

    public bool HasNeighbourOnTop { get; set; }

    public bool HasNeighbourOnTopToRight { get; set; }

    public bool HasNeighbourToRight { get; set; }

    public bool HasNeighbourOnBottomToRight { get; set; }

    public bool HasNeighbourOnBottom { get; set; }

    public bool HasNeighbourOnBottomToLeft { get; set; }

    public bool HasNeighbourToLeft { get; set; }

    public bool HasNeighbourOnTopToLeft { get; set; }
}

public record ItemsIntersectionInfo
{
    public ItemsIntersectionInfo(
        BooleanElementInfo firstNodeItem,
        BooleanElementInfo lastNodeItem)
    {
        this.FirstNode = firstNodeItem;
        this.LastNode = lastNodeItem;
    }

    public BooleanElementInfo FirstNode { get; }
    public BooleanElementInfo LastNode { get; }
}
