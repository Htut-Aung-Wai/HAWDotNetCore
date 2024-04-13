



using System.Data.SqlClient;
using System.Data;

Console.WriteLine("Hello, World!");


//regionread

SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
sqlConnectionStringBuilder.DataSource = ".";
sqlConnectionStringBuilder.InitialCatalog = "TestDb";
sqlConnectionStringBuilder.UserID = "sa";
sqlConnectionStringBuilder.Password = "sa@123";

SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

sqlConnection.Open();

string query = "select * from tbl_blog";
SqlCommand cmd = new SqlCommand(query, sqlConnection);
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
adapter.Fill(dt);

sqlConnection.Close();

foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine(dr["BlogId"]);
    Console.WriteLine(dr["BlogTitle"]);
    Console.WriteLine(dr["BlogAuthor"]);
    Console.WriteLine(dr["BlogContent"]);
}
//endregion