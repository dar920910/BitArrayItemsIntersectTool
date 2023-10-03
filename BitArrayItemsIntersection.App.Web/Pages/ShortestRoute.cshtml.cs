//-----------------------------------------------------------------------
// <copyright file="ShortestRoute.cshtml.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1649 // FileNameMustMatchTypeName

using BitArrayItemsIntersection.Library;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ShortestRouteModel : PageModel
{
    public ShortestRouteModel()
    {
        if (DataStore.RouteElements is not null)
        {
            this.RouteBuildResultMessage = "The Shortest Route was successfully built!";
        }
        else
        {
            this.RouteBuildResultMessage = "Cannot build the Shortest Route between elements!";
        }
    }

    public string RouteBuildResultMessage { get; }

    public void OnGet()
    {
        this.ViewData["Title"] = "Shortest Route Page";
    }

    public string GetNodeElementValue(byte elementRow, byte elementCol)
    {
        BooleanElementInfo element = new (
            elementRow, elementCol, DataStore.CurrentArray.Content[elementRow, elementCol]);

        if (this.IsRouteSourceElement(element))
        {
            return "A";
        }

        if (this.IsRouteTargetElement(element))
        {
            return "B";
        }

        if (DataStore.RouteElements.Contains(element))
        {
            return $"Node ({element.IsCharged})";
        }

        return element.IsCharged.ToString();
    }

    public string GetElementClass(byte elementRow, byte elementCol)
    {
        BooleanElementInfo element = new (
            elementRow, elementCol, DataStore.CurrentArray.Content[elementRow, elementCol]);

        if (this.IsRouteSourceElement(element) || this.IsRouteTargetElement(element))
        {
            return "route_bound";
        }
        else if (DataStore.RouteElements.Contains(element))
        {
            return "route_node";
        }
        else
        {
            return "another_element";
        }
    }

    private bool IsRouteSourceElement(BooleanElementInfo element) =>
        (element.Row == DataStore.RouteElement_A.Row) && (element.Column == DataStore.RouteElement_A.Col);

    private bool IsRouteTargetElement(BooleanElementInfo element) =>
        (element.Row == DataStore.RouteElement_B.Row) && (element.Column == DataStore.RouteElement_B.Col);
}
