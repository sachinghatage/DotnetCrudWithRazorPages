using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserApplication.Model;

namespace UserApplication.Pages.User
{
    public class CreateModel : PageModel
    {
        public Users users = new Users();
        public string successMessage = string.Empty;
        public string failureMessage = string.Empty;

        private readonly IConfiguration configuration;

        public CreateModel(IConfiguration configuration)
        {

            this.configuration = configuration;

        }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            users.FirstName = Request.Form["FirstName"];
            users.LastName = Request.Form["LastName"];
            users.Email = Request.Form["Email"];

            if(users.FirstName.Length==0 || users.LastName.Length==0)
            {
                failureMessage = "All fields are required";
                return;
            }

            try
            {
                DataAccessLayer dal=new DataAccessLayer();
                dal.AddUser(users, configuration);
            }
            catch(Exception ex)
            {
                failureMessage= ex.Message;
                return;
            }

            users.FirstName = "";
            users.LastName = "";
            users.Email= "";
            successMessage = "user has been added successfully";
            Response.Redirect("/User/Index");
        }
    }
}
