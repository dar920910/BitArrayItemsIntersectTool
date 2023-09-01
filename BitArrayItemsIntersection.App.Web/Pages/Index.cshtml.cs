using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    [BindProperty]
    public byte CustomDimension_X { get; set; }

    [BindProperty]
    public byte CustomDimension_Y { get; set; }

    public IndexModel()
    {
        CustomDimension_X = 25;
        CustomDimension_Y = 75;
    }

    public void OnGet()
    {
        ViewData["Title"] = "Home Page";
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            DataStore.ArrayDimension_X = CustomDimension_X;
            DataStore.ArrayDimension_Y = CustomDimension_Y;

            return RedirectToPage("/matrix");
        }
        else
        {
            return Page();
        }
    }
}