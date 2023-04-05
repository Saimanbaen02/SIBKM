using System.Data;
using System.Data.SqlClient;

namespace Connection1;

//Connection to database sibkm
public class Program
{
    private static SqlConnection connection;

    private static string connectionString = "Data Source=DESKTOP-T6HLL2P;Initial Catalog=sibkm;Integrated Security=True;Connect Timeout=30;Encrypt=False";

    public static void Main()
    {
        connection = new SqlConnection(connectionString);
        try
        {
            connection.Open();
            Console.WriteLine("Connection Open!");
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Connection Failed : " + e);
        }

        //GetAllCountries();
    }
    //Get All : Countries
    public static void GetAllCountries()
    {
        connection = new SqlConnection(connectionString);

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Select * From countries;";

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine("Id : " + reader[0]);
                Console.WriteLine("Name : " + reader[1]);
                Console.WriteLine("Region Id : " + reader[2]);
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Countries is Empty!");
        }
        reader.Close();
        connection.Close();

        //GetByIdCountries("AU");
    }
    
    //Get By Id : Countries
    public static void GetByIdCountries(string country_id)
    {
        connection = new SqlConnection(connectionString);

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Select * From countries Where country_id = @id;";

        SqlParameter pCountry_id = new SqlParameter();
        pCountry_id.ParameterName = "@id";
        pCountry_id.SqlDbType = SqlDbType.VarChar;
        pCountry_id.Value = country_id;
        command.Parameters.Add(pCountry_id);

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine("Id : " + reader[0]);
                Console.WriteLine("Name : " + reader[1]);
                Console.WriteLine("Region_id : " + reader[2]);
            }
        }
        else
        {
            Console.WriteLine($"Country_id = {country_id} is not found!");
        }
        reader.Close();
        connection.Close();

        //InsertCountries("Indonesia");
    }
    //Insert Countries
    public static void InsertCountries(string name)
    {
        connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Insert Into countries (country_name) Values (@country_name);";
            command.Transaction = transaction;

            SqlParameter pCountry_name = new SqlParameter();
            pCountry_name.ParameterName = "@country_name";
            pCountry_name.SqlDbType = System.Data.SqlDbType.VarChar;
            pCountry_name.Value = name;
            command.Parameters.Add(pCountry_name);

            command.ExecuteNonQuery();

            transaction.Commit();
            Console.WriteLine("Insert Success!");
            connection.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Something Wrong! : " + e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        //UpdateCountries("AU", "Update Australia 2");
    }
    // UPDATE : Countries
    public static void UpdateCountries(string country_id, string country_name)
    {
        connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Update Countries Set country_name = @name Where country_id = @id;";
            command.Transaction = transaction;

            SqlParameter pCountry_name = new SqlParameter();
            pCountry_name.ParameterName = "@name";
            pCountry_name.SqlDbType = System.Data.SqlDbType.VarChar;
            pCountry_name.Value = country_name;
            command.Parameters.Add(pCountry_name);

            SqlParameter pCountry_id = new SqlParameter();
            pCountry_id.ParameterName = "@id";
            pCountry_id.SqlDbType = System.Data.SqlDbType.VarChar;
            pCountry_id.Value = country_id;
            command.Parameters.Add(pCountry_id);

            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Update Success!");
            }
            else
            {
                Console.WriteLine($"Country_id = {country_id} is not found!");
            }

            transaction.Commit();
            connection.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Something Wrong! : " + e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
       
        //DeleteCountries("AR");
    }

    // DELETE : Countries
    public static void DeleteCountries(string country_id)
    {
        connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Delete From Countries Where country_id = @id;";
            command.Transaction = transaction;

            SqlParameter pCountry_id = new SqlParameter();
            pCountry_id.ParameterName = "@id";
            pCountry_id.SqlDbType = System.Data.SqlDbType.VarChar;
            pCountry_id.Value = country_id;
            command.Parameters.Add(pCountry_id);

            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Delete Success!");
            }
            else
            {
                Console.WriteLine($"id = {country_id} is not found!");
            }
            transaction.Commit();
            connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Something Wrong! : " + e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }

}



