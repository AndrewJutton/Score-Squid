using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Web.Security;

namespace ScoreSquid.Web.Authentication
{
    public class PlayerIdentity : IIdentity
    {
        private FormsAuthenticationTicket ticket;

        public PlayerIdentity(FormsAuthenticationTicket ticket)
        {
            this.ticket = ticket;
        }

        public string AuthenticationType
        {
            get { return "ScoreSquid"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public string Name
        {
            get { return ticket.Name; }
        }

        public string FriendlyName
        {
            get { return ticket.UserData; }
        }

    }
}