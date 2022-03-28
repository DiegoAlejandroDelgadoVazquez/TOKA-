using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TEST_DEV_API_DADV_26032022.DataAccess
{
    public class ConnectionObject
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ToString();
    }
}