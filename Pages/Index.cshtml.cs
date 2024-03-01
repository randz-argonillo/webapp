using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webapp.Models;
using webapp.Services;

namespace webapp.Pages
{
  public class IndexModel : PageModel
  {
    private List<Product> _products = new List<Product>();

    public List<Product> Products
    {
      get => _products;
      private set => _products = value;
    }

    public void OnGet()
    {
      var productService = new ProductService();

      Products = productService.GetProducts();
    }
  }
}