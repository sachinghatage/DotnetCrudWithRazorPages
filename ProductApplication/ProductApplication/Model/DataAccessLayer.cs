using System.Data.SqlClient;
namespace ProductApplication.Model
{
    public class DataAccessLayer
    {
        public  void SaveProduct(Products product, IConfiguration configuration)
        {
            
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DBCS").ToString()))
            {
                SqlCommand command = new SqlCommand("insert into products values('"+product.ProductName+ "','"+product.Price+"','"+product.StockQuantity+"')",connection);
                connection.Open();
               command.ExecuteNonQuery();
                connection.Close();


            }
            
        }

        public List<Products> GetProduct(IConfiguration configuration)
        {
            List<Products> listProducts=new List<Products>();
            using(SqlConnection connection=new SqlConnection(configuration.GetConnectionString("DBCS")))
            {
                connection.Open();
                string query = "select * from products";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Products products = new Products();
                            products.ProductId = Convert.ToString(reader["ProductId"]);
                            products.ProductName =Convert.ToString(reader["ProductName"]);
                            products.Price = Convert.ToDouble(reader["Price"]);
                            products.StockQuantity =Convert.ToInt32(reader["StockQuantity"]);

                            listProducts.Add(products);
                        }
                    }
                }
            }
            return listProducts;
        }

        public int DeleteStudent(string id,IConfiguration configuration)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DBCS").ToString()))
            {
                connection.Open();
                string query = "delete from  products where productId ='" + id + "'";
                SqlCommand command = new SqlCommand(query, connection);
                i = command.ExecuteNonQuery();
            }

            return i;
        }

        public Products GetSingleProduct(string id,IConfiguration configuration)
        {
            Products product = new Products();
            using(SqlConnection connection=new SqlConnection(configuration.GetConnectionString("DBCS").ToString()))
            {
                connection.Open();
                string query = "select * from products where productId='"+id+"'";
                using(SqlCommand command=new SqlCommand(query,connection))
                {
                    using(SqlDataReader reader=command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            product.ProductId = Convert.ToString(reader["ProductId"]);
                            product.ProductName =Convert.ToString( reader["ProductName"]);
                            product.Price =Convert.ToDouble( reader["Price"]);
                            product.StockQuantity =Convert.ToInt32( reader["StockQuantity"]);
                        }
                    }
                }
            }

            return product;

        }

        public int UpdateProduct(Products product,IConfiguration configuration)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DBCS").ToString()))
            {
                connection.Open();
                string query = "update products set productName='"+product.ProductName+"',price='"+product.Price+"',stockQuantity='"+product.StockQuantity+"' where productId='"+product.ProductId+"'";
                SqlCommand command = new SqlCommand(query, connection) ;
                i=command.ExecuteNonQuery();
            }

                return i;
        }
    }
}
