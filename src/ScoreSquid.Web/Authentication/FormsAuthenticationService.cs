using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ScoreSquid.Web.Authentication
{
    public class FormsAuthenticationService : IFormsAuthentication
    {
        public void SignIn(string userName, bool createPersistentCookie)
        {
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                1,
                userName,
                DateTime.Now,
                DateTime.Now.AddMinutes(30),
                createPersistentCookie,
                userName);

            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}