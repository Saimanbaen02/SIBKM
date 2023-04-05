using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Contexts;
public class MyContext
{
    private static SqlConnection connection;

    private static string connectionString = "Data Source=DESKTOP-T6HLL2P;Initial Catalog=sibkm;Integrated Security=True;Connect Timeout=30;Encrypt=False";
    public static SqlConnection GetConnection()
    {
        try
        {
            connection = new SqlConnection(connectionString);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return connection;
    }
}
