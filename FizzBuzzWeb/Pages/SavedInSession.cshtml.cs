using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FizzBuzzWeb.Pages
{
    public class SavedInSessionModel : PageModel
    {
        public FizzBuzzForm FizzBuzz { get; set; }
        public void OnGet()
        {
            var data = HttpContext.Session.GetString("Data");

            if (data != null)
            {
                FizzBuzz = JsonConvert.DeserializeObject<FizzBuzzForm>(data);
            }
        }
    }
}