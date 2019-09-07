using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Pages
{
    public class ThankYouModel : PageModel
    {
        public string Name { get; set; }

        public IActionResult OnGet(string name)
        {
            Name = name;
            return Page();
        }
    }
}