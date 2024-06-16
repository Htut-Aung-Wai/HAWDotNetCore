using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAWDotNetCore.ConsoleApp
{
    internal class DapperExample
    {
        public void Run()
        {
            Read();
        }

        public void Read()
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            List<BlogDTO> lst = db.Query<BlogDTO>("select * from tbl_blog").ToList(); 
            foreach (BlogDTO item in lst)
            {
                Console.WriteLine(item.BlogID);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("______________________");
            }
           


        }
    }
}
