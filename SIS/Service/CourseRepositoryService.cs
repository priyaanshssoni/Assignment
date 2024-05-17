using System;
using SIS.Exceptions;
using SIS.Model;
using SIS.Repository;

namespace SIS.Service
{
	public class CourseRepositoryService

	{
        readonly iCourseRepository _courserepo;
        readonly iTeacherRepository _teachrepo;

        public CourseRepositoryService()
		{
            _courserepo = new CourseRepository();
		}



        public void AssignTeacher()
		{
            try
            {
                Teacher teacher = new Teacher();
                Course c = new Course();
                Console.WriteLine("~Welcome To Teacher Assignment Department~");
                Console.WriteLine("~Please Fill below details ~");
                List<Course> cc = _courserepo.getallcourse();
                foreach (Course cour in cc)
                {
                    Console.WriteLine(
     $"Course Id : {cour.CourseId} || " +
     $"Course Code : {cour.CourseCode} || " +
     $"Course Name : {cour.CourseName}"
 );
                }
                Console.WriteLine("Select Course Id");
                c.CourseId = int.Parse(Console.ReadLine());
                List<Teacher> t2 = _courserepo.getallteacher();
                foreach (Teacher item in t2)
                {
                    Console.WriteLine($"Teacher Id : {item.teacherId} || Teacher Name :: {item.firstName} {item.lastName}");
                }
                Console.WriteLine("Select Teacher Id");
                teacher.teacherId = Convert.ToInt32(Console.ReadLine());
                
                int status = _courserepo.AssignTeacher(teacher, c);
                if (status > 0) { Console.WriteLine("Assigning Teacher Successful"); }
            }
            catch (TeacherNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (CourseNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void DisplayCourseInfo()
        {
            try
            {
                Course course = new Course();
                Console.WriteLine("~Welcome To Course Department~");
                Console.WriteLine("~Please Fill below details ~");
                Console.WriteLine("Course Id");
                course.CourseId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(_courserepo.DisplayCourseInfo(course));
            }
            catch (CourseNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void GetEnrollments()
        {
            try
            {
                Course course = new Course();
                Console.WriteLine("~Welcome To Course Department~");
                Console.WriteLine("~Please Fill below details ~");
                List<Course> cc = _courserepo.getallcourse();
                foreach (Course cour in cc)
                {
                    Console.WriteLine(
     $"Course Id : {cour.CourseId} || " +
     $"Course Code : {cour.CourseCode} || " +
     $"Course Name : {cour.CourseName}"
 );
                }
                Console.WriteLine("Course Id");
                course.CourseId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                List<Student> stu = _courserepo.GetEnrollments(course); ;
                foreach (Student item in stu)
                {
                    Console.WriteLine(item);
                }


            }
            catch (CourseNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void GetTeacher()
        {
            Course course = new Course();
            Console.WriteLine("~Welcome To Course Department~");
            Console.WriteLine("~Please Fill below details ~");
            List<Course> cc = _courserepo.getallcourse();
            foreach (Course cour in cc)
            {
                Console.WriteLine(
 $"Course Id : {cour.CourseId} || " +
 $"Course Code : {cour.CourseCode} || " +
 $"Course Name : {cour.CourseName}"
);
            }
            Console.WriteLine("Course Id");
            course.CourseId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Teacher Assigned For Course ID {course.CourseId} :" + _courserepo.GetTeacher(course));

        }

        public void UpdateCourseInfo()
        {
            try
            {
                Console.WriteLine("~Welcome To Course Department~");
                Console.WriteLine("~Please Fill below details ~");
                List<Course> cc = _courserepo.getallcourse();
                foreach (Course cour in cc)
                {
                    Console.WriteLine(
     $"Course Id : {cour.CourseId} || " +
     $"Course Code : {cour.CourseCode} || " +
     $"Course Name : {cour.CourseName}"
 );
                }
                Console.WriteLine("Course Id");
                int cid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Course Code");
                string code = (Console.ReadLine());
                Console.WriteLine("Course Name");
                string cname =(Console.ReadLine());
                List<Teacher> t2 = _courserepo.getallteacher();
                foreach (Teacher item in t2)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Select The Instructor");
                int instructor = Convert.ToInt32(Console.ReadLine());
                int updatecourse = _courserepo.UpdateCourseInfo(cid, code, cname, instructor);
                if (updatecourse > 0)
                { Console.WriteLine("Course Updation Successful"); }
                else
                    Console.WriteLine("Course Updation UnSuccessful");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


    }
}

