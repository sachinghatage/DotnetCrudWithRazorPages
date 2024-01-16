using System.Data;
using System.Data.SqlClient;

namespace UserApplication.Model
{
    public class DataAccessLayer
    {
        public List<Users> getUsers(IConfiguration configuration)
        {
            List<Users> listUsers = new List<Users>();

            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DBCS").ToString()))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from users", connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        Users users = new Users();
                        users.Id = Convert.ToString(dataTable.Rows[i]["Id"]);
                        users.FirstName = Convert.ToString(dataTable.Rows[i]["FirstName"]);
                        users.LastName = Convert.ToString(dataTable.Rows[i]["LastName"]);
                        users.Email = Convert.ToString(dataTable.Rows[i]["Email"]);

                        listUsers.Add(users);
                    }
                }
            }

            return listUsers;
        }



        public int AddUser(Users user, IConfiguration configuration)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DBCS").ToString()))
            {
                SqlCommand command = new SqlCommand("insert into users values('" + user.FirstName + "','" + user.LastName + "','" + user.Email + "')", connection);
                connection.Open();
                i = command.ExecuteNonQuery();
                connection.Close();

            }

            return i;


        }

        /* public int addUser(Users user, IConfiguration configuration)
         {
             int rowsAffected = 0;

             try
             {
                 string connectionString = configuration.GetConnectionString("DBCS").ToString();

                 using (SqlConnection connection = new SqlConnection(connectionString))
                 {
                     string query = "INSERT INTO users (FirstName, LastName, EmailId) VALUES (@FirstName, @LastName, @EmailId('@EmailId')";
                     SqlCommand command = new SqlCommand(query, connection);

                     command.Parameters.AddWithValue("@FirstName", user.FirstName);
                     command.Parameters.AddWithValue("@LastName", user.LastName);
                     command.Parameters.AddWithValue("@EmailId", user.EmailId);

                     connection.Open();
                     rowsAffected = command.ExecuteNonQuery();
                 }
             }
             catch (Exception ex)
             {
                 // Handle the exception (log or throw)
                 Console.WriteLine("Error inserting email: " + ex.Message);
                 throw;
             }

             return rowsAffected;
         }*/



        public Users getUser(string id, IConfiguration configuration)
        {
            Users users = new Users();

            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DBCS").ToString()))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from users where id='" + id + "'", connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {

                    {

                        users.Id = Convert.ToString(dataTable.Rows[0]["Id"]);
                        users.FirstName = Convert.ToString(dataTable.Rows[0]["FirstName"]);
                        users.LastName = Convert.ToString(dataTable.Rows[0]["LastName"]);
                        users.Email = Convert.ToString(dataTable.Rows[0]["Email"]);



                    }
                }
            }

            return users;
        }

        public int updateUser(Users user, IConfiguration configuration)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DBCS").ToString()))
            {
                SqlCommand command = new SqlCommand("update users set FirstName='" + user.FirstName + "',LastName='" + user.LastName + "',Email='" + user.Email +"' where id='" + user.Id + "'", connection);
                connection.Open();
                i = command.ExecuteNonQuery();
                connection.Close();

            }

            return i;


        }

        public int deleteUser(string id, IConfiguration configuration)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DBCS").ToString()))
            {
                SqlCommand command = new SqlCommand("delete from users where id='" + id + "'", connection);
                connection.Open();
                i = command.ExecuteNonQuery();
                connection.Close();

            }

            return i;

        }
    }
}