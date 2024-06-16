using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAWDotNetCore.ConsoleApp
{
    internal static class ConnectionStrings
    {

        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog= "TestDb",
            UserID = "sa",
            Password = "sa@123"


        };
    }
}
