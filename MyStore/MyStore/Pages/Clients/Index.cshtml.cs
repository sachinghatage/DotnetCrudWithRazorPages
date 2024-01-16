using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace MyStore.Pages.Clients
{
    public class IndexModel : PageModel
    {

        public List<ClientInfo> listClients=new List<ClientInfo>(); 

        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=SANTOSHLAPTOP\\SQLEXPRESS;Initial Catalog=mystore;Integrated Security=True;Trust Server Certificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "select * from clients";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClientInfo clientInfo = new ClientInfo();
                                clientInfo.id = "" + reader.GetInt32(0);
                                clientInfo.name = reader.GetString(1);
                                clientInfo.email = reader.GetString(2);
                                clientInfo.createdTime = reader.GetDateTime(3).ToString();

                                listClients.Add(clientInfo);
                            }
                        }
                    }



                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }


    public class ClientInfo
    {
        public string id;
        public string name;
        public string email;
        public string createdTime;
    }
}
