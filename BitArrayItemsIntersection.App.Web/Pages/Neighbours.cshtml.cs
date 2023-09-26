//-----------------------------------------------------------------------
// <copyright file="Neighbours.cshtml.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1649 // FileNameMustMatchTypeName

using BitArrayItemsIntersection.Library;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class NeighboursModel : PageModel
{
    public NeighboursModel()
    {
        this.CurrentRow = DataStore.CurrentElementRow;
        this.CurrentCol = DataStore.CurrentElementCol;

        this.TargetArray = DataStore.CurrentMatrixModel.TargetArray;

        this.NeighbourElements = this.TargetArray.FindNeighbourElementsAt(
            elementRow: this.CurrentRow, elementColumn: this.CurrentCol);
    }

    public byte CurrentRow { get; }

    public byte CurrentCol { get; }

    public CustomBooleanArray TargetArray { get; }

    public List<BooleanElementInfo> NeighbourElements { get; }

    public void OnGet()
    {
        this.ViewData["Title"] = "Neighbours Page";
    }

    public string GetElementClass(byte elementRow, byte elementCol)
    {
        BooleanElementInfo element = new (
            elementRow, elementCol, this.TargetArray.Content[elementRow, elementCol]);

        if ((element.Row == this.CurrentRow) && (element.Column == this.CurrentCol))
        {
            return "current_element";
        }
        else if (this.NeighbourElements.Contains(element))
        {
            return element.IsCharged ?
                "neighbour_charged" : "neighbour_noncharged";
        }
        else
        {
            return "another_element";
        }
    }
}
