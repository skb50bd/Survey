using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Web.Pages.Responses
{
    public class SummaryModel : PageModel
    {
        public ResponseSummary ResponseSummary { get; set; }

        public void OnGet()
        {

        }
    }
}