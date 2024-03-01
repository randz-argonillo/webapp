using System.Data.SqlClient;
using webapp.Models;

namespace webapp.Services
{
  public class ProductService
  {
    private SqlConnection GetSqlConnection()
    {
      SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
      builder.DataSource = "webapp10045.database.windows.net";
      builder.InitialCatalog = "webapp";
      builder.UserID = "zamiek";
      builder.Password = "nyradzkie5985@";

      return new SqlConnection(builder.ConnectionString);
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
