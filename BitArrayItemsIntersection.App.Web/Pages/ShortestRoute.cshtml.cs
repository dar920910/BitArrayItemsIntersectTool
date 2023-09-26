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
        this.TargetArray = DataStore.CurrentMatrixModel.TargetArray;

        this.RouteElement_A = DataStore.RouteElement_A;
        this.RouteElement_B = DataStore.RouteElement_B;

        BooleanArrayAnalyzer analyzer = new (this.TargetArray);

        if (analyzer.CanTryToMakeRouteBetweenArrayElements(
            from: this.RouteElement_A, to: this.RouteElement_B))
        {
            this.RouteElements = analyzer.FindShortestRouteBetween(
                routeSource: this.RouteElement_A,
                routeTarget: this.RouteElement_B);

            this.RouteBuildResultMessage = "The Shortest Route was successfully built!";
        }
        else
        {
            this.RouteElements = Array.Empty<BooleanElementInfo>();
            this.RouteBuildResultMessage = "Cannot build the Shortest Route between elements!";
        }
    }

    public CustomBooleanArray TargetArray { get; }

    public (byte Row, byte Col) RouteElement_A { get; }

    public (byte Row, byte Col) RouteElement_B { get; }

    public BooleanElementInfo[] RouteElements { get; }

    public string RouteBuildResultMessage { get; }

    public void OnGet()
    {
        this.ViewData["Title"] = "Shortest Route Page";
    }

    public string GetNodeElementValue(byte elementRow, byte elementCol)
    {
        BooleanElementInfo element = new (
            elementRow, elementCol, this.TargetArray.Content[elementRow, elementCol]);

        if (this.IsRouteSourceElement(element))
        {
            return "A";
        }

        if (this.IsRouteTargetElement(element))
        {
            return "B";
        }

        if (this.RouteElements.Contains(element))
        {
            return $"Node ({element.IsCharged})";
        }

        return element.IsCharged.ToString();
    }

    public string GetElementClass(byte elementRow, byte elementCol)
    {
        BooleanElementInfo element = new (
            elementRow, elementCol, this.TargetArray.Content[elementRow, elementCol]);

        if (this.IsRouteSourceElement(element) || this.IsRouteTargetElement(element))
        {
            return "route_bound";
        }
        else if (this.RouteElements.Contains(element))
        {
            return "route_node";
        }
        else
        {
            return "another_element";
        }
    }

    private bool IsRouteSourceElement(BooleanElementInfo element) =>
        (element.Row == this.RouteElement_A.Row) && (element.Column == this.RouteElement_A.Col);

    private bool IsRouteTargetElement(BooleanElementInfo element) =>
        (element.Row == this.RouteElement_B.Row) && (element.Column == this.RouteElement_B.Col);
}
