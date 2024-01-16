using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductApplication.Model;
using System.Security.Cryptography.X509Certificates;

namespace ProductApplication.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration configuration;
        public Products product = new Products();

        public IndexModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void OnGet()
        {
        }

        public void OnPost() 
        {
            product.ProductName = Request.Form["ProductName"];
            product.Price =Convert.ToDouble(Request.Form["Price"]);
            product.StockQuantity =Convert.ToInt32(Request.Form["StockQuantity"]);

            DataAccessLayer dal=new DataAccessLayer();
            dal.SaveProduct(product,configuration);

           
        }
    }
}
