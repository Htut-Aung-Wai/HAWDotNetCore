using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace HAWDotNetCore.ConsoleApp
{
    internal class DapperExample
    {
        public void Run()
        {
            Read();
            //Edit(11);
            //Create("htut13","htut13","htut13");
            //Update(1012, "htut15", "htut15", "htut15");
            //Delete(1011);
        }

        private void Read()
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            List<BlogDTO> lst = db.Query<BlogDTO>("select * from tbl_blog").ToList();  //Dapper
            foreach (BlogDTO item in lst)
            {
                Console.WriteLine(item.BlogID);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("______________________");
            }
           


        }

        private void Edit(int id)
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            var item=db.Query<BlogDTO>("select * from tbl_blog where blogid=@Blogid",new BlogDTO { BlogID=id}).FirstOrDefault();
            if(item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }
            Console.WriteLine(item.BlogID);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("______________________");
        }

        private void Create(string title,string author,string content)
        {

            var item = new BlogDTO
            {

                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content

            };
            string query = @"INSERT INTO [dbo].[Tbl_Blog] ([BlogTitle],[BlogAuthor],[BlogContent]) VALUES(@BlogTitle,@BlogAuthor,@BlogContent)";
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            int result=db.Execute(query,item);
            string message = result > 0 ? "Saving Successful" : "Saving Fail";
            Console.WriteLine(message);
        }

        private void Update(int id,string title, string author, string content)
        {
            var item = new BlogDTO
            {
                BlogID=id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content

            };
            string query = @"UPDATE [dbo].[Tbl_Blog] SET [BlogTitle] = @BlogTitle,[BlogAuthor] = @BlogAuthor,[BlogContent] = @BlogContent WHERE BlogId = @BlogID";
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);
            string message = result > 0 ? "Update Successful" : "Update Fail";
            Console.WriteLine(message);

        }
        private void Delete(int id)
        {
            var item = new BlogDTO
            {
                BlogID = id
             

            };
            string query = @"delete from Tbl_Blog where BlogId = @BlogId";
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);
            string message = result > 0 ? "Delete Successful" : "Delete Fail";
            Console.WriteLine(message);

        }
    }
}
