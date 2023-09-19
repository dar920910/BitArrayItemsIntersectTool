
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

    public string GetElementClass(byte elementRow, byte elementCol)
    {
        BooleanElementInfo element = new(elementRow, elementCol,
            TargetArray.Content[elementRow, elementCol]);

        if ( (element.Row == CurrentRow) && (element.Column == CurrentCol) )
        {
            return "current_element";
        }
        else if (NeighbourElements.Contains(element))
        {
            return element.IsCharged ?
                "neighbour_charged" : "neighbour_noncharged";
        }
        else
        {
            return "another_element";
        }
    }
}
