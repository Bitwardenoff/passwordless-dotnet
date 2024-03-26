using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Passwordless.AspNetIdentity.Example.Authorization;

namespace Passwordless.AspNetIdentity.Example.Pages.Authorized;

[Authorize(Policy = ElevationRequirement.PolicyName)]
public class ElevatedAuthentication : PageModel
{
    public void OnGet()
    {
    }
}