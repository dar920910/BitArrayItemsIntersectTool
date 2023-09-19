
using Microsoft.AspNetCore.Mvc.RazorPages;
using BitArrayItemsIntersection.Library;

public class NeighboursModel : PageModel
{
    public readonly byte CurrentRow;
    public readonly byte CurrentCol;

    public readonly CustomBooleanArray TargetArray;
    public readonly List<BooleanElementInfo> NeighbourElements;

    public NeighboursModel()
    {
        CurrentRow = DataStore.CurrentElementRow;
        CurrentCol = DataStore.CurrentElementCol;

        TargetArray = DataStore.CurrentMatrixModel.TargetArray;

        NeighbourElements = TargetArray.FindNeighbourElementsAt(
            elementRow: CurrentRow, elementColumn: CurrentCol
        );
    }

    public void OnGet()
    {
        ViewData["Title"] = "Neighbours Page";
    }
}
