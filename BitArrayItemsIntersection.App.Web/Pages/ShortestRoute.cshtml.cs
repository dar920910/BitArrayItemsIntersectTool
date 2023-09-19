using Microsoft.AspNetCore.Mvc.RazorPages;
using BitArrayItemsIntersection.Library;

public class ShortestRouteModel : PageModel
{
    public readonly CustomBooleanArray TargetArray;

    public readonly (byte Row, byte Col) RouteElement_A;
    public readonly (byte Row, byte Col) RouteElement_B;

    public readonly BooleanElementInfo[] RouteElements;

    public readonly string RouteBuildResultMessage;

    public ShortestRouteModel()
    {
        TargetArray = DataStore.CurrentMatrixModel.TargetArray;

        RouteElement_A = DataStore.RouteElement_A;
        RouteElement_B = DataStore.RouteElement_B;

        BooleanArrayAnalyzer analyzer = new(TargetArray);

        if (analyzer.CanTryToMakeRouteBetweenArrayElements(
            from: RouteElement_A, to: RouteElement_B))
        {
            RouteElements = analyzer.FindShortestRouteBetween(
                routeSource: RouteElement_A,
                routeTarget: RouteElement_B
            );

            RouteBuildResultMessage = "The Shortest Route was successfully built!";
        }
        else
        {
            RouteElements = Array.Empty<BooleanElementInfo>();
            RouteBuildResultMessage = "Cannot build the Shortest Route between elements!";
        }
    }

    public void OnGet()
    {
        ViewData["Title"] = "Shortest Route Page";
    }

    public string GetNodeElementValue(byte elementRow, byte elementCol)
    {
        BooleanElementInfo element = new(elementRow, elementCol,
            TargetArray.Content[elementRow, elementCol]);

        if (IsRouteSourceElement(element))
        {
            return "A";
        }
        
        if (IsRouteTargetElement(element))
        {
            return "B";
        }

        if (RouteElements.Contains(element))
        {
            return $"Node ({element.IsCharged})";
        }

        return element.IsCharged.ToString();
    }

    public string GetElementClass(byte elementRow, byte elementCol)
    {
        BooleanElementInfo element = new(elementRow, elementCol,
            TargetArray.Content[elementRow, elementCol]);

        if ( IsRouteSourceElement(element) || IsRouteTargetElement(element) )
        {
            return "route_bound";
        }
        else if (RouteElements.Contains(element))
        {
            return "route_node";
        }
        else
        {
            return "another_element";
        }
    }

    private bool IsRouteSourceElement(BooleanElementInfo element) =>
        (element.Row == RouteElement_A.Row) && (element.Column == RouteElement_A.Col);

    private bool IsRouteTargetElement(BooleanElementInfo element) =>
        (element.Row == RouteElement_B.Row) && (element.Column == RouteElement_B.Col);
}
