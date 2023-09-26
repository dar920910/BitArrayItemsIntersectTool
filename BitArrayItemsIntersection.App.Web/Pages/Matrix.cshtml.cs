//-----------------------------------------------------------------------
// <copyright file="Matrix.cshtml.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1649 // FileNameMustMatchTypeName

using BitArrayItemsIntersection.Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class MatrixModel : PageModel
{
    public MatrixModel()
    {
        this.TargetArray = CustomBooleanArray.GenerateRandomBooleanArray(
            rows: DataStore.ArrayRowsDimension,
            columns: DataStore.ArrayColsDimension);

        this.LastElement = (
            Row: Convert.ToByte(this.TargetArray.CountOfRows - 1),
            Column: Convert.ToByte(this.TargetArray.CountOfColumns - 1));

        this.RouteElementRow_A = 0;
        this.RouteElementCol_A = 0;

        this.RouteElementRow_B = this.LastElement.Row;
        this.RouteElementCol_B = this.LastElement.Column;
    }

    public CustomBooleanArray TargetArray { get; }

    public (byte Row, byte Column) LastElement { get; }

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

    public static string GetElementClass(bool elementValue) =>
        elementValue ? "charged" : "noncharged";

    public void OnGet()
    {
        this.ViewData["Title"] = "Target Matrix";
    }

    public IActionResult OnPostFindElementNeighbours()
    {
        if (this.ModelState.IsValid)
        {
            DataStore.CurrentMatrixModel = this;
            DataStore.CurrentElementRow = this.SelectedElementRow;
            DataStore.CurrentElementCol = this.SelectedElementCol;

            return this.RedirectToPage("/neighbours");
        }
        else
        {
            return this.Page();
        }
    }

    public IActionResult OnPostFindShortestRouteBetweenElements()
    {
        if (this.ModelState.IsValid)
        {
            DataStore.CurrentMatrixModel = this;
            DataStore.RouteElement_A = (this.RouteElementRow_A, this.RouteElementCol_A);
            DataStore.RouteElement_B = (this.RouteElementRow_B, this.RouteElementCol_B);

            return this.RedirectToPage("/shortestroute");
        }
        else
        {
            return this.Page();
        }
    }
}
