using Microsoft.AspNetCore.Mvc.RazorPages;
using BitArrayItemsIntersection.Library;
using Microsoft.AspNetCore.Mvc;

public class MatrixModel : PageModel
{
    [BindProperty]
    public byte SelectedElementRow { get; set; }

    [BindProperty]
    public byte SelectedElementColumn { get; set; }


    [BindProperty]
    public byte RouteRowCoordinate_A { get; set; }

    [BindProperty]
    public byte RouteColCoordinate_A { get; set; }

    [BindProperty]
    public byte RouteRowCoordinate_B { get; set; }

    [BindProperty]
    public byte RouteColCoordinate_B { get; set; }


    public readonly (byte Row, byte Column) LastElement;


    public CustomBooleanArray TargetArray { get; }

    public MatrixModel()
    {
        TargetArray = CustomBooleanArray.GenerateRandomBooleanArray(
            rows: DataStore.ArrayDimension_Y,
            columns: DataStore.ArrayDimension_X
        );

        LastElement = 
        (
            Row: Convert.ToByte(TargetArray.CountOfRows - 1),
            Column: Convert.ToByte(TargetArray.CountOfColumns - 1)
        );

        RouteRowCoordinate_A = 0;
        RouteColCoordinate_A = 0;

        RouteRowCoordinate_B = LastElement.Row;
        RouteColCoordinate_B = LastElement.Column;
    }

    public void OnGet()
    {
        ViewData["Title"] = "Target Matrix";
        DataStore.CurrentMatrixModel = this;
    }

    public static string GetElementClass(bool elementValue)
    {
        return elementValue ? "charged" : "noncharged";
    }
}
