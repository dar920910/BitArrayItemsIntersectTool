//-----------------------------------------------------------------------
// <copyright file="Index.cshtml.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1649 // FileNameMustMatchTypeName

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    public IndexModel()
    {
        this.CustomRowsDimension = 10;
        this.CustomColsDimension = 10;
    }

    [BindProperty]
    public byte CustomRowsDimension { get; set; }

    [BindProperty]
    public byte CustomColsDimension { get; set; }

    public void OnGet()
    {
        this.ViewData["Title"] = "Home Page";
    }

    public IActionResult OnPost()
    {
        if (this.ModelState.IsValid)
        {
            DataStore.ArrayRowsDimension = this.CustomRowsDimension;
            DataStore.ArrayColsDimension = this.CustomColsDimension;

            return this.RedirectToPage("/matrix");
        }
        else
        {
            return this.Page();
        }
    }
}
