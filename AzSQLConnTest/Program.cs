using System.Data.SqlClient;
using System.Diagnostics;




//input the serverName
Console.WriteLine("Enter the server name:");
string? serverName = Console.ReadLine();

//input the databaseName
Console.WriteLine("Enter the database name:");
string? databaseName = Console.ReadLine();

//input the userName
Console.WriteLine("Enter the user name:");
string? userName = Console.ReadLine();

//input the password
Console.WriteLine("Enter the password:");
string? password = Console.ReadLine();

//input the number of trials
Console.WriteLine("How many trials:");
int numberOfConnections=1; 
int.TryParse(Console.ReadLine(),out numberOfConnections);

//Stopwatch
Stopwatch stopwatch = new Stopwatch();

//building the connection
var builder = new SqlConnectionStringBuilder();
builder.DataSource = serverName;
builder.UserID = userName;
builder.Password = password;
builder.InitialCatalog = databaseName;

stopwatch.Start();
for (int i = 0; i < numberOfConnections; i++)
{
    try { 
    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
    {
        connection.Open();
        
        connection.Close();
    }
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
stopwatch.Stop();
Console.WriteLine("Total Time elapsed: {0}", stopwatch.Elapsed);
Console.WriteLine("Time elapsed per connection: {0}", stopwatch.Elapsed / numberOfConnections);
stopwatch.Reset();
Console.WriteLine("Press any key to close");
Console.ReadKey(true);