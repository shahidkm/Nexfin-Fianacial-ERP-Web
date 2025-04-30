namespace CompanyService.Api.Middleware
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
            if (context.Request.Headers.TryGetValue("CompanyId",out var CompanyId))
            {
                context.Items["CompanyId"] = CompanyId.ToString();
            }
            _next(context);
        }
    }
}
