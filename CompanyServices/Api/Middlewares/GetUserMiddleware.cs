using System.Security.Claims;

namespace CompanyServices.Api.Middlewares
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
                var emailClaim = context.User.FindFirst(ClaimTypes.Email);
                var companyClaim = context.User.FindFirst("CompanyId");
                if (idClaim != null)
                {
                    context.Items["UserId"] = idClaim.Value;
                  
                }

                if (emailClaim != null)
                {
                    
                    context.Items["Email"] = emailClaim.Value;
                }
                if (companyClaim != null)
                {

                    context.Items["CompanyId"] = companyClaim.Value;
                }

            }
            await _next(context);

        }
    }
}
