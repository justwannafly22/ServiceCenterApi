using ClientApi.Infrastructure.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace ClientApi.Controllers
{
    [Authorize(TokenAuthorizationHandler.Policy)]
    public class BaseController : Controller
    {
        public static string GetErrorMessage(ModelStateDictionary modelState)
        {
            return string.Join(" ", modelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)));
        }
    }
}
