using System.Security.Claims;

namespace CompanyService.Api.Middleware
{
    public class GetUserMiddleware
    {
        private readonly RequestDelegate _next;

        public GetUserMiddleware(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }



        public async Task Invoke(HttpContext context)
        {
            if (context.User.Identity?.IsAuthenticated == true)
            {
                var idClaim = context.User.FindFirst(ClaimTypes.NameIdentifier);

                if (idClaim != null)
                {
                    context.Items["UserId"] = idClaim.Value;

                }


            }
            await _next(context);

        }
    }
}
