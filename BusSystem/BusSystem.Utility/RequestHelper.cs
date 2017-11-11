using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace System.Web
{
    public static class RequestHelper
    {
        public static bool IsPostBack(this HttpRequest request)
        {
            return request.HttpMethod.Equals("post", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
