using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Class
{
    public class Services
    {
        // Buscar usuarios por email
        static public void SearchUserByEmail(List<User> listUsers, string email) //Lista de usuarios y email
        {
            var users = listUsers.FindAll(user => user.Email.Equals(email));
        }

        // Buscar alumnos mayores de edad
        static public void SearchStudentsByLegalAge(List<Student> listStudents)
        {
            var students = listStudents.FindAll(user => CalculateAge(user.Dob) >= 18);
        }

        static public int CalculateAge(DateTime DoB)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - DoB.Year;
            if (now < DoB.AddYears(age))
                age--;
            return age;
        }

        // Buscar alumnos que tengan al menos un curso
        static public void SearchStudentWithAtLeastCourse(List<Student> listStudents)
        {
            var students = listStudents.FindAll(user => user.Courses.Any());
        }

        // Buscar cursos de un nivel determinado que al menos tengan un alumno inscrito
        static public void SearchCoursesWithCertainLevelAndAtLeastStudent(List<Course> listCourses, string level)
        {
            var courses = listCourses.FindAll(course => course.Levels.Equals(level) && course.Students.Any());
        }

        // Buscar cursos de un nivel determinado que sean de una categoría determinada
        static public void SearchCoursesWithCertainLevelFromCertainCategory(List<Course> listCourses, string level, string category)
        {
            var courses = listCourses.FindAll(course => course.Levels.Equals(level) && course.Categories.Any(category => category.Equals(category)));
        }

        // Buscar cursos sin alumnos
        static public void SearchCoursesWithoutStudents(List<Course> listCourse)
        {
            var courses = listCourse.FindAll(course => course.Students.Count() == 0);
        }

    }
}