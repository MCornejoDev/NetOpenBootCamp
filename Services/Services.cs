using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using universityApiBackend.Models.DataModels;

namespace Services
{
    public class Services
    {
        // Buscar usuarios por email
        static public User SearchUserByEmail(List<User> listUsers, string email) //Lista de usuarios y email
        {
            return listUsers.First(user => user.Email.Equals(email));
        }

        // Buscar alumnos mayores de edad
        static public void SearchStudentByLegalAge(string email)
        {

        }

        // Buscar alumnos que tengan al menos un curso
        static public void SearchStudentWithAtLeastCourse()
        {

        }

        // Buscar cursos de un nivel determinado que al menos tengan un alumno inscrito
        static public void SearchCoursesWithCertainLevelAndAtLeastStudent()
        {

        }

        // Buscar cursos de un nivel determinado que sean de una categoría determinada
        static public void SearchCoursesWithCertainLevelFromCertainCategory()
        {

        }

        // Buscar cursos sin alumnos
        static public void SearchCoursesWithoutStudents()
        {

        }

    }

}