using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using StudentApplication.Model;

namespace StudentApplication.Pages.Student
{
    public class DisplaySingleModel : PageModel
    {

        public DisplaySingleModel(IConfiguration configuration) 
        {
            this.configuration = configuration;
        }
        public Students student=new Students();
        private readonly IConfiguration configuration;

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public Students Student { get; set; }
        public void OnGet()
        {
            if(!string.IsNullOrEmpty(Id))
            {
                DataAccessLayer dal = new DataAccessLayer();
                student = dal.getStudent(Id, configuration);
            }
            else
            {
                Console.WriteLine("Student with ID " + Id + " not found");
            }
           
        }
    }
}
