using Microsoft.AspNetCore.Mvc.RazorPages;
using BitArrayItemsIntersection.Library;

public class MatrixModel : PageModel
{
    public CustomBooleanArray TargetArray { get; }

    public MatrixModel()
    {
        TargetArray = new CustomBooleanArray(DataStore.ArrayDimension_X, DataStore.ArrayDimension_Y);
    }

    public void OnGet()
    {
        ViewData["Title"] = "Target Matrix";
    }
}
