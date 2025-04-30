namespace CompanyServices.Api.Middlewares
{
    public class GetCompanyMiddleware
    {
        private readonly RequestDelegate _next;

        public GetCompanyMiddleware(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            // Check for CompanyId in request headers
            if (context.Request.Headers.TryGetValue("CompanyId", out var companyIdHeader))
            {
                // Safely convert to int and store in HttpContext.Items
                if (int.TryParse(companyIdHeader, out int companyId))
                {
                    context.Items["CompanyId"] = companyId; // Store as int
                }
                else
                {
                    // Optionally log or handle invalid CompanyId format
                }
            }

            // Proceed to the next middleware
            await _next(context);
        }
    }
}
