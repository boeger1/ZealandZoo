using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ZealandZooAPP.Pages.Account
{
    public class LoginModelModel : PageModel
    {
        [BindProperty]
        public Credential? Credential { get; set; }

        public void OnGet()
        {
            
        }

        public async Task <IActionResult> OnPostAsync() 
        {
            if (ModelState.IsValid) return Page();

            if(Credential.UserName == "admin" && Credential.Password == "password")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email, "admin@zealandzoo.dk")
                };
                var identity = new ClaimsIdentity(claims, "MyCookie");
                ClaimsPrincipal Principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookie", Principal);

                return RedirectToPage("/Index");
            }
            return Page();
        }
    }

    public class Credential
    {
        [Required]
        [Display(Name = " User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
