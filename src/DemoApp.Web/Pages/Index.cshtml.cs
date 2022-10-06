using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace DemoApp.Web.Pages;

public class IndexModel : DemoAppPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
