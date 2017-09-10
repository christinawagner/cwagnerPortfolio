using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Util;

namespace cwagnerPortfolio.Helpers
{
    public static class HtmlExtensions
    {
        public static HtmlString FileTextAsContent(this HtmlHelper helper, string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return new HtmlString(string.Empty);
            }
            var path = HostingEnvironment.MapPath(url);
            var text = File.ReadAllText(path);
            return new HtmlString(text);
        }
    }
}