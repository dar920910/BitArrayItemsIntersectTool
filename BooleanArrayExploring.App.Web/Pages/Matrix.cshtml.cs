//-----------------------------------------------------------------------
// <copyright file="Matrix.cshtml.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1649 // FileNameMustMatchTypeName

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class MatrixModel : PageModel
{
    public MatrixModel()
    {
        this.RouteElementRow_A = 0;
        this.RouteElementCol_A = 0;

        this.RouteElementRow_B = DataStore.LastElement.Row;
        this.RouteElementCol_B = DataStore.LastElement.Column;
    }

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
            DataStore.InitializeNeighbourElements(
                this.SelectedElementRow, this.SelectedElementCol);

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
            DataStore.InitializeShortestRouteBetweenElements(
                element_A: (this.RouteElementRow_A, this.RouteElementCol_A),
                element_B: (this.RouteElementRow_B, this.RouteElementCol_B));

            return this.RedirectToPage("/shortestroute");
        }
        else
        {
            return this.Page();
        }
    }
}
