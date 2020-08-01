using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web
{
    /// <summary>
    /// This is a configuration file that contains settings relvant to the Application
    /// </summary>
    public static class BlogConfig
    {
        private static int pageSize = 0;
        public static int DefaultPageSize
        {
            get
            {
                if (pageSize == 0)
                {
                    pageSize = int.Parse(System.Configuration.ConfigurationManager.AppSettings["PagingSize"]);
                }

                return pageSize;
            }
        }
    }
}