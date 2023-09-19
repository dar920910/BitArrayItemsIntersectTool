using Microsoft.AspNetCore.Mvc.RazorPages;
using BitArrayItemsIntersection.Library;
using Microsoft.AspNetCore.Mvc;

public class MatrixModel : PageModel
{
    [BindProperty]
    public byte SelectedElementRow { get; set; }

    [BindProperty]
    public byte SelectedElementCol { get; set; }


    [BindProperty]
    public byte RouteElementRow_A { get; set; }

    [BindProperty]
    public byte RouteElementCol_A { get; set; }

    [BindProperty]
    public byte RouteElementRow_B { get; set; }

    [BindProperty]
    public byte RouteElementCol_B { get; set; }


    public readonly (byte Row, byte Column) LastElement;


    public CustomBooleanArray TargetArray { get; }

    public MatrixModel()
    {
        TargetArray = CustomBooleanArray.GenerateRandomBooleanArray(
            rows: DataStore.ArrayRowsDimension,
            columns: DataStore.ArrayColsDimension
        );

        LastElement = 
        (
            Row: Convert.ToByte(TargetArray.CountOfRows - 1),
            Column: Convert.ToByte(TargetArray.CountOfColumns - 1)
        );

        RouteElementRow_A = 0;
        RouteElementCol_A = 0;

        RouteElementRow_B = LastElement.Row;
        RouteElementCol_B = LastElement.Column;
    }

    public void OnGet()
    {
        ViewData["Title"] = "Target Matrix";
    }

    public IActionResult OnPostFindElementNeighbours()
    {
        if (ModelState.IsValid)
        {
            DataStore.CurrentMatrixModel = this;
            DataStore.CurrentElementRow = SelectedElementRow;
            DataStore.CurrentElementCol = SelectedElementCol;

            return RedirectToPage("/neighbours");
        }
        else
        {
            return Page();
        }
    }

    public IActionResult OnPostFindShortestRouteBetweenElements()
    {
        if (ModelState.IsValid)
        {
            DataStore.CurrentMatrixModel = this;
            DataStore.RouteElement_A = (RouteElementRow_A, RouteElementCol_A);
            DataStore.RouteElement_B = (RouteElementRow_B, RouteElementCol_B);

            return RedirectToPage("/shortestroute");
        }
        else
        {
            return Page();
        }
    }

    public static string GetElementClass(bool elementValue)
    {
        return elementValue ? "charged" : "noncharged";
    }
}
