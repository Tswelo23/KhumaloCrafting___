using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KhumaloCrafting___.Models

{
    [Authorize (Roles ="Admin")]
    public class AdminPageModel
    {
        public void OnGet()
        {


        }
    }
}
