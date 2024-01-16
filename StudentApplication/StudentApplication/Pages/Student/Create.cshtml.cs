using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentApplication.Model;

namespace StudentApplication.Pages.Student
{
    public class CreateModel : PageModel
    {
        public Students students = new Students();
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
            students.FirstName = Request.Form["FirstName"];
            students.LastName = Request.Form["LastName"];
            students.Email = Request.Form["Email"];


            if (students.FirstName.Length == 0 || students.LastName.Length == 0)
            {
                failureMessage = "All fields are required";
                return;
            }

            try
            {
                DataAccessLayer dal = new DataAccessLayer();
                dal.AddStudent(students, configuration);
            }
            catch (Exception ex)
            {
                failureMessage = ex.Message;
                return;
            }

            students.FirstName = "";
            students.LastName = "";
            students.Email = "";

            successMessage = "student has been added successfully";
            Response.Redirect("/Student/Index");
        }
    }
}
