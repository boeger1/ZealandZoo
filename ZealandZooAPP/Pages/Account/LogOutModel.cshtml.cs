using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZealandZooAPP.Pages.Account;

public class LogOutModelModel : PageModel
{/// <summary>
/// sarah
/// </summary>
/// <returns></returns>
    public async Task<IActionResult> OnPostAsync()
    { //fjerner cookies ved log ud
        await HttpContext.SignOutAsync("MyCookie");
        return RedirectToPage("/Index");
    }
}