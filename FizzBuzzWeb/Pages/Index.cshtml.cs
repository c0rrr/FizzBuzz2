using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty(SupportsGet = true)]
        public FizzBuzzForm FizzBuzz { get; set; }
        public List<FizzBuzzForm> FizzBuzzList = new List<FizzBuzzForm>();
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                var data = HttpContext.Session.GetString("Data");

                if (data != null)
                {
                    FizzBuzzList = JsonConvert.DeserializeObject<List<FizzBuzzForm>>(data);
                }
                if(FizzBuzzList != null)    FizzBuzzList.Add(FizzBuzz);
                HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(FizzBuzzList));
                return Page();
            }
            return RedirectToPage("./Privacy");
        }
    }
}