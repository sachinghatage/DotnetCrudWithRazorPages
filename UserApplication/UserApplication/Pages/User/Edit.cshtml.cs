using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserApplication.Model;

namespace UserApplication.Pages.User
{
    public class EditModel : PageModel
    {
        public Users user = new Users();
        public string successMessage = string.Empty;
        public string failureMessage = string.Empty;

        private readonly IConfiguration configuration;

        public EditModel(IConfiguration configuration)
        {

            this.configuration = configuration;

        }
        public void OnGet()
        {
            string id = Request.Query["id"];
            try
            {
                DataAccessLayer dal= new DataAccessLayer();
                user=dal.getUser(id, configuration);

            }
            catch (Exception ex)
            {
                failureMessage=ex.Message;
               
            }
        }


        public void OnPost()
        {
            user.Id = Request.Form["hiddenId"];
            user.FirstName = Request.Form["FirstName"];
            user.LastName = Request.Form["LastName"];
            user.Email = Request.Form["Email"];

            if (user.FirstName.Length == 0 || user.LastName.Length == 0)
            {
                failureMessage = "All fields are required";
                return;
            }

            try
            {
                DataAccessLayer dal = new DataAccessLayer();
                dal.updateUser(user, configuration);
            }
            catch (Exception ex)
            {
                failureMessage = ex.Message;
                return;
            }

            user.FirstName = "";
            user.LastName = "";
            user.Email = "";
            successMessage = "user has been updated successfully";
            Response.Redirect("/User/Index");
        }
    }
}
