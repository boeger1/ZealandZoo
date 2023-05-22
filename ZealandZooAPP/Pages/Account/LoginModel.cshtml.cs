using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZealandZooAPP.Pages.Account;

public class LoginModelModel : PageModel
{
    [BindProperty] public Credential? Proof { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        //if (ModelState.IsValid) return Page();

        if (Proof.UserName == "admin" && Proof.Password == "password")
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, "admin"),
                new(ClaimTypes.Role, "admin")
            };
            var identity = new ClaimsIdentity(claims, "MyCookie");
            var Principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("MyCookie", Principal);

            return RedirectToPage("/Index");
        }

        return Page();
    }
}

public class Credential
{
    [Required]
    [Display(Name = " Username")]
    public string UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}