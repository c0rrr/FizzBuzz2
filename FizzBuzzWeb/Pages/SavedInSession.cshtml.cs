using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FizzBuzzWeb.Pages
{
    public class SavedInSessionModel : PageModel
    {
        public List<FizzBuzzForm> FizzBuzzList = new List<FizzBuzzForm>();
        public void OnGet()
        {
            var data = HttpContext.Session.GetString("Data");

            if (data != null )
            {
                FizzBuzzList = JsonConvert.DeserializeObject<List<FizzBuzzForm>>(data);
            }
            if (FizzBuzzList == null ) RedirectToPage("./Privacy");
        }
    }
}