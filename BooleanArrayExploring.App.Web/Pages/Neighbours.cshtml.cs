//-----------------------------------------------------------------------
// <copyright file="Neighbours.cshtml.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1649 // FileNameMustMatchTypeName

using BooleanArrayExploring.Library;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class NeighboursModel : PageModel
{
    public NeighboursModel()
    {
    }

    public void OnGet()
    {
        this.ViewData["Title"] = "Neighbours Page";
    }

    public string GetElementClass(byte elementRow, byte elementCol)
    {
        BooleanElementInfo element = new (
            elementRow, elementCol, DataStore.CurrentArray.Content[elementRow, elementCol]);

        if ((element.Row == DataStore.CurrentElementRow) && (element.Column == DataStore.CurrentElementCol))
        {
            return "current_element";
        }
        else if (DataStore.NeighbourElements.Contains(element))
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
