
using HAWDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;


Console.WriteLine("Hello, World!");


AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
adoDotNetExample.Create("htutcreate", "htut", "createhtut");
//adoDotNetExample.Read();
//adoDotNetExample.Update(2, "htutbook", "htut", "hi this is htut");
//adoDotNetExample.Delete(14);
//adoDotNetExample.Edit(11);
Console.ReadKey();



/* 
Ctrl + . = suggestion
F11 = run into the function step by step
F10 = run line by line
F9 = set breakpoint
*/
// dataset => datatable
// datatable => datarow
// datarow => datacolumn