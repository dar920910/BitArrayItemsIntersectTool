
using Microsoft.AspNetCore.Mvc.RazorPages;
using BitArrayItemsIntersection.Library;
using Microsoft.AspNetCore.Mvc;

public class NeighboursModel : PageModel
{
    public readonly CustomBooleanArray TargetArray;
    public byte CurrentRow { get; set; }
    public byte CurrentCol { get; set; }

    public NeighboursModel()
    {
        TargetArray = DataStore.CurrentMatrixModel.TargetArray;
    }

    public void OnGet()
    {
        ViewData["Title"] = "Neighbours Page";

        CurrentRow = Convert.ToByte(RouteData.Values["SelectedElementRow"]);
        CurrentCol = Convert.ToByte(RouteData.Values["SelectedElementColumn"]);
    }
}