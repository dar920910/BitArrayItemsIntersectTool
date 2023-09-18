using Microsoft.AspNetCore.Mvc.RazorPages;
using BitArrayItemsIntersection.Library;

public class ShortestRouteModel : PageModel
{
    public readonly CustomBooleanArray TargetArray;
    public ShortestRouteModel()
    {
        TargetArray = DataStore.CurrentMatrixModel.TargetArray;
    }

    public void OnGet()
    {
        ViewData["Title"] = "Shortest Route Page";
    }
}