using CourseProject.Models;

namespace CourseProject.Web.Models
{
    public class AdDetailsModel
    {
        public Advertisement Advertisement { get; set; }

        public bool BookButtonVisible { get; set; }

        public bool SaveButtonVisible { get; set; }
    }
}