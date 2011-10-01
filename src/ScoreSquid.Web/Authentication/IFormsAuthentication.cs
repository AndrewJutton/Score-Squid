using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreSquid.Web.Authentication
{
    public interface IFormsAuthentication
    {
        void SignIn(string userName, bool createPersistentCookie);

        void SignOut();
    }
}