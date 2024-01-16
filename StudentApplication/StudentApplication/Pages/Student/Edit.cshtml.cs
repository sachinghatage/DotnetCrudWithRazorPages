using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentApplication.Model;

namespace StudentApplication.Pages.Student
{
    public class EditModel : PageModel
    {
        public Students student = new Students();
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
                DataAccessLayer dal = new DataAccessLayer();
                student = dal.getStudent(id, configuration);

            }
            catch (Exception ex)
            {
                failureMessage = ex.Message;

            }
        }


        public void OnPost()
        {
            student.Id = Request.Form["hiddenId"];
            student.FirstName = Request.Form["FirstName"];
            student.LastName = Request.Form["LastName"];
            student.Email = Request.Form["Email"];

            if (student.FirstName.Length == 0 || student.LastName.Length == 0)
            {
                failureMessage = "All fields are required";
                return;
            }

            try
            {
                DataAccessLayer dal = new DataAccessLayer();
                dal.updateStudent(student, configuration);
            }
            catch (Exception ex)
            {
                failureMessage = ex.Message;
                return;
            }

            student.FirstName = "";
            student.LastName = "";
            student.Email = "";
            successMessage = "student has been updated successfully";
            Response.Redirect("/Student/Index");
        }
    }
}
