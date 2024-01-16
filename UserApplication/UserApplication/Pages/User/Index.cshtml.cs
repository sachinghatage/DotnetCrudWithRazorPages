using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserApplication.Model;

namespace UserApplication.Pages.User
{
    public class IndexModel : PageModel
    {

        private readonly IConfiguration configuration;
        public List<Users> listUsers = new List<Users>();

        public IndexModel(IConfiguration configuration)
        {
            this.configuration = configuration; 
        }
        public void OnGet()
        {
            DataAccessLayer dal=new DataAccessLayer();
            listUsers=dal.getUsers(configuration);
        }
    }
}
