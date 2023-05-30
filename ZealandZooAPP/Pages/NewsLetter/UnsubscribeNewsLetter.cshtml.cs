using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages.NewsLetter;

public class UnsubscribeNewsLetterModel : PageModel
{
    private readonly StudentRepoService _studentRepoService;

    public UnsubscribeNewsLetterModel(StudentRepoService studentRepoService)
    {
        _studentRepoService = studentRepoService;
    }

    public void OnGet(string email)
    {
        _studentRepoService.NewsLetterUnSubscribe(email);
    }
}