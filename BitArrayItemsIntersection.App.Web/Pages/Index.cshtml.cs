using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    [BindProperty]
    public byte CustomRowsDimension { get; set; }

    [BindProperty]
    public byte CustomColsDimension { get; set; }

    public IndexModel()
    {
        CustomRowsDimension = 10;
        CustomColsDimension = 10;
    }

    public void OnGet()
    {
        ViewData["Title"] = "Home Page";
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            DataStore.ArrayRowsDimension = CustomRowsDimension;
            DataStore.ArrayColsDimension = CustomColsDimension;

            return RedirectToPage("/matrix");
        }
        else
        {
            return Page();
        }
    }
}