using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductApplication.Model;

namespace ProductApplication.Pages.Product
{
    public class ListModel : PageModel
    {
        public readonly IConfiguration configuration;
        public List<Products> listProducts=new List<Products>();

        public ListModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void OnGet()
        {
            DataAccessLayer dal=new DataAccessLayer();
            listProducts=dal.GetProduct(configuration);

        }
    }
}
