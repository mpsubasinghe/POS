using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using I_MiddleLayer;
using System.Configuration;

namespace DAL
{
    public class CommonDAL
    {
        protected SqlConnection objConn = null;
        protected SqlCommand objCommand = null;

        //protected List<AnyType> AnyTypes = new List<AnyType>();
        public CommonDAL()
        {
            if ((objConn == null) || (objConn.State == ConnectionState.Closed))
            {
                objConn = new SqlConnection(ConfigurationManager.
                        ConnectionStrings["Conn"].ConnectionString);
                objConn.Open();
                
                
            }
        }
    }
}
