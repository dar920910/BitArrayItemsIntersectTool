using Microsoft.AspNetCore.Mvc.RazorPages;
using BitArrayItemsIntersection.Library;

public class MatrixModel : PageModel
{
    public (byte Row, byte Column) SelectedElement { get; set; }

    public CustomBooleanArray TargetArray { get; }

    public MatrixModel()
    {
        TargetArray = CustomBooleanArray.GenerateRandomBooleanArray(
            rows: DataStore.ArrayDimension_Y,
            columns: DataStore.ArrayDimension_X
        );

        SelectedElement = (Row: 0, Column: 0);
    }

    public void OnGet()
    {
        ViewData["Title"] = "Target Matrix";
    }

    public static string GetElementClass(bool elementValue)
    {
        return elementValue ? "charged" : "noncharged";
    }
}
