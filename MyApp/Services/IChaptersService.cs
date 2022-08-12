using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public interface IChaptersService
    {
        IEnumerable<Chapter> GetChaptersFromCertainCourse(int IdCourse);
    }
}