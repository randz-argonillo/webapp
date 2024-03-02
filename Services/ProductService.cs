using System.Data.SqlClient;
using webapp.Models;

namespace webapp.Services
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;

        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private SqlConnection GetSqlConnection()
        {
            var sqlCnString = _configuration.GetConnectionString("sqlconnection");
            return new SqlConnection(sqlCnString);
        }

        public List<Product> GetProducts()
        {
            var sql = "Select * from dbo.Products";
            var cn = GetSqlConnection();
            cn.Open();

            var products = new List<Product>();
            SqlCommand cmd = new SqlCommand(sql, cn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    products.Add(new Product()
                    {
                        ProductId = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2),
                    });
                }
            }

            return products;
        }
    }
}
