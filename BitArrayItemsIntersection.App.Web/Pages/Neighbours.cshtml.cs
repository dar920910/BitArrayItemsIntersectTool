
using Microsoft.AspNetCore.Mvc.RazorPages;
using BitArrayItemsIntersection.Library;
using Microsoft.AspNetCore.Mvc;

public class NeighboursModel : PageModel
{
    public readonly CustomBooleanArray TargetArray;
    public byte CurrentRow;
    public byte CurrentColumn;

    public NeighboursModel()
    {
        TargetArray = DataStore.CurrentMatrixModel.TargetArray;
    }

    public void OnGet()
    {
        ViewData["Title"] = "Neighbours Page";
    }

    public IActionResult OnPost()
    {
        CurrentRow = DataStore.SelectedElementRow;
        CurrentColumn = DataStore.SelectedElementColumn;

        return Page();
    }
}