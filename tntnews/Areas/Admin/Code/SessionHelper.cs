using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tntnews.Areas.Admin.Code
{
    public class SessionHelper
    {
        public static void SetSession(Session session)
        {
            HttpContext.Current.Session["loginSession"] = session;
        }

        public static Session GetSession()
        {
            var session = HttpContext.Current.Session["loginSession"];
            if (session == null)
                return null;
            else
            {
                return session as Session;
            }

        }
    }
}