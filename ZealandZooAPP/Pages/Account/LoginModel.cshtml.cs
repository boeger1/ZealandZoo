using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZealandZooAPP.Pages.Account;
/// <summary>
/// sarah
/// </summary>

public class LoginModelModel : PageModel
{/// <summary>
/// sarah
/// </summary>
    [BindProperty] public Credential Proof { get; set; }

    public void OnGet()
    {
    }
    /// <summary>
    /// sarah
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> OnPostAsync()
    { 
        
        //vertifisere at Username og password matcher.
        if (Proof.UserName == "admin" && Proof.Password == "password")
        {
            //opretter en liste med brugerens identitet og rolle
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, "admin"),
                new(ClaimTypes.Role, "admin")
            };
            //claims bliver omdannet til en cookie 
            var identity = new ClaimsIdentity(claims, "MyCookie");
            
            var Principal = new ClaimsPrincipal(identity);
            //udsteder en cokkie til autentificering til brugeren
            await HttpContext.SignInAsync("MyCookie", Principal);
            

            return RedirectToPage("/Index");
        }

        return Page();
    }

    /// <summary>
    /// Sarah
    /// </summary>
    public class Credential
    {   // propperties til klassen Credential 
        [Required(ErrorMessage = "Ugyldigt navn")]
        [Display(Name = " Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Ugyldigt password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}