using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using GroceryStore.Models;

namespace GroceryStore.Pages
{
    public class IndexModel : PageModel
    {
        public List<GroceryItem> Foods = Inventory.ToList();

        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Feedback { get; set; }

        public void OnGet()
        {

        }

        public async Task OnPostAsync()
        {
            Console.WriteLine(Email);
            if(Email != "" && Feedback != "")
            {
                using (StreamWriter writer = new StreamWriter("feedbackLog.txt", append: true))
                {
                    await writer.WriteLineAsync($"{DateTime.Now}\n{Email}\n\"{Feedback}\"");
                }
            }
        }
    }
}