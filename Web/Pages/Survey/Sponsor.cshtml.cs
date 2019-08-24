using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using static System.IO.File; 

namespace Web.Pages.Survey
{
    public class SponsorModel : PageModel
    {
        public JObject Questions;

        public void OnGet()
        {
            Questions = JObject.Parse(ReadAllText("sponsor-form.json"));
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}