using Microsoft.AspNetCore.Mvc;
using PRN221_Project.Business.Helper;

namespace PRN221_Project.Business.Middleware
{
    public class AuthorizeMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            int? lectureId = Helper.Helper.GetIdFromSession(context.Session, Constants.LECTURE_ID_KEY);

            // check if not logged in and route is not /signin => redirect to signin
            if (lectureId == null && !context.Request.Path.Equals(Constants.ROUTE_SIGN_IN, StringComparison.OrdinalIgnoreCase))
            {
                // No active session, redirect to login page
                context.Response.Redirect(Constants.ROUTE_SIGN_IN);
                return;
            }

            // check if logged in and route is /signin => redirect to signin
            if (lectureId != null && context.Request.Path.Equals(Constants.ROUTE_SIGN_IN, StringComparison.OrdinalIgnoreCase))
            {
                // Active session, redirect to home page
                context.Response.Redirect(Constants.ROUTE_HOME);
                return;
            }

            // Active session, proceed to next middleware
            await _next(context);
        }
    }
}
