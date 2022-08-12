using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public class CoursesService : ICoursesService
    {
        // TODO methods
        //Get courses from certain category
        IEnumerable<Course> ICoursesService.GetCoursesFromCertainCategory(string category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetCoursesWihtNotChapters()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetCoursesWithNotStudents()
        {
            throw new NotImplementedException();
        }
    }
}