using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductApplication.Model;

namespace ProductApplication.Pages.Product
{
    public class EditModel : PageModel
    {
        private readonly IConfiguration configuration;
        public Products product = new Products();
        public EditModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void OnGet()
        {
            string id= Request.Query["id"];
            try
            {
                DataAccessLayer dal = new DataAccessLayer();
                product = dal.GetSingleProduct(id, configuration);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void OnPost()
        {
            product.ProductId = Request.Form["hiddenId"];
            product.ProductName = Request.Form["ProductName"];
            product.Price =Convert.ToDouble( Request.Form["Price"]);
            product.StockQuantity =Convert.ToInt32( Request.Form["StockQuantity"]);

            try
            {
                DataAccessLayer dal = new DataAccessLayer();
                dal.UpdateProduct(product, configuration);
            }
            catch(Exception ex) 
            {
                Console.Write(ex.Message);
            }

            Response.Redirect("/Product/List");

        }
    }
}
