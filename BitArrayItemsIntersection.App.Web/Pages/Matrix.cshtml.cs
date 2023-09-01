using Microsoft.AspNetCore.Mvc.RazorPages;
using BitArrayItemsIntersection.Library;

public class MatrixModel : PageModel
{
    public bool[,] TargetArray { get; }
    public int Dimension_X { get; }
    public int Dimension_Y { get; }

    public MatrixModel()
    {
        CustomBooleanArray array = new(DataStore.ArrayDimension_X, DataStore.ArrayDimension_Y);
        TargetArray = array.Content;
        Dimension_X = TargetArray.GetLength(0);
        Dimension_Y = TargetArray.GetLength(1);
    }

    public void OnGet()
    {
        ViewData["Title"] = "Target Matrix";
    }
}
