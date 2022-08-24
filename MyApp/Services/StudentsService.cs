using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly ILogger<StudentsService> _logger;

        public StudentsService(ILogger<StudentsService> logger)
        {
            _logger = logger;
        }

        //TODO : resolve Methods
        public IEnumerable<Student> GetStudentsWithCourses()
        {
            _logger.LogWarning($"{nameof(StudentsService)} - {nameof(GetStudentsWithCourses)} - Warning Level Log");
            _logger.LogError($"{nameof(StudentsService)} - {nameof(GetStudentsWithCourses)} - Error Level Log");
            _logger.LogCritical($"{nameof(StudentsService)} - {nameof(GetStudentsWithCourses)} - Critical Level Log");

            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudentsWithNotCourses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudentsFromCertainCourse(int IdCourse)
        {
            throw new NotImplementedException();
        }
    }
}