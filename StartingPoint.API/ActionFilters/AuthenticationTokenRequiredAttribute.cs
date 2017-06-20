using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace StartingPoint.API.ActionFilters
{
    public class AuthenticationTokenRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            String token = actionContext.Request.Headers.GetValues("Token").First();

            if (String.IsNullOrEmpty(token))
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }

            Boolean validToken = false;
            //TODO: Validate token

            if (!validToken)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }

        }

    }
}