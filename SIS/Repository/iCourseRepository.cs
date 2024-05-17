using System;
using Microsoft.Data.SqlClient;
using SIS.Model;

namespace SIS.Repository
{
	public interface iCourseRepository
	{

    int      AssignTeacher(Teacher teacher, Course course);
    int      UpdateCourseInfo(int CourseId, string CourseCode, string CourseName, int instructor);
    Course   DisplayCourseInfo(Course course);
    List<Student>    GetEnrollments(Course course);
    string  GetTeacher(Course course);
        public List<Teacher> getallteacher();

        public bool CourseNotFound(Course course);
        bool CheckIfTeacherIdExists(Teacher teacher);
        List<Course> getallcourse();




    }
}

