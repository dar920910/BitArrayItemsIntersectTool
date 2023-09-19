
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
        CurrentRow = DataStore.CurrentElementRow;
        CurrentCol = DataStore.CurrentElementCol;
    }

    public void OnGet()
    {
        ViewData["Title"] = "Neighbours Page";
    }
}