using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public interface ICoursesService
    {
        IEnumerable<Course> GetCoursesFromCertainCategory(string category);
        IEnumerable<Course> GetCoursesWihtNotChapters();
        IEnumerable<Course> GetCoursesWithNotStudents();
    }
}