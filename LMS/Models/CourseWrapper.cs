using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class CourseWrapper
    {
        public Course SelectedCourse { get; set; }
        public List<CourseEntry> Entries { get; set; }
        public List<Course> ListOfCourses { get; set; }
    }
}
