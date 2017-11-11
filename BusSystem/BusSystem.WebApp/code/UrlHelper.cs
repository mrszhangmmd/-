using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusSystem.WebApp.code
{
    public static class UrlHelper
    {
        public static string CategoryUrl(int categoryId)
        {
            return string.Format("/list-{0}-0-1.aspx", categoryId);
        }
    }
}