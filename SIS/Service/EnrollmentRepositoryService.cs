using System;
using SIS.Model;
using SIS.Repository;

namespace SIS.Service
{
	public class EnrollmentRepositoryService
	{
        readonly iEnrollmentRepository _enrollrepo;
        public EnrollmentRepositoryService()
        {
            _enrollrepo = new EnrollmentRepository();
        }

        public void GetStudent()
        {
            try
            {
                Enrollment enrollment = new Enrollment();
                Console.WriteLine("~Welcome To Enrollment Department~");
                Console.WriteLine("~Please Fill below details ~");
                Console.WriteLine("Enrollment Id");
                enrollment.enrollId = int.Parse(Console.ReadLine());
                Console.WriteLine($"Enrollment Id {enrollment.enrollId} :: Student Name :: " + _enrollrepo.GetStudent(enrollment));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void GetCourse()
        {
            try
            {
                Enrollment enrollment = new Enrollment();
                Console.WriteLine("~Welcome To Enrollment Department~");
                Console.WriteLine("~Please Fill below details ~");
                Console.WriteLine("Enrollment Id");
                enrollment.enrollId = int.Parse(Console.ReadLine());
    
                Console.WriteLine($"Enrollment Id :: {enrollment.enrollId} :: Course Name :: " + _enrollrepo.GetCourse(enrollment));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void GenerateEnrollReport()
        {
            Enrollment enrollment = new Enrollment();
            Console.WriteLine("~Welcome To Enrollment Report Creation~");
            List<Course> cc = _enrollrepo.getallcourse();
            foreach (Course cour in cc)
            {
                Console.WriteLine(
 $"Course Id : {cour.CourseId}  " +
 $"Course Name : {cour.CourseName}"
);
            }
            Console.WriteLine("Select Course Id");
            enrollment.courseId = int.Parse(Console.ReadLine());
            List<Student> stu = _enrollrepo.GenerateEnrollReport(enrollment);
            foreach(Student a in stu)
            {
                Console.WriteLine(a);
            }


        }




    }
}

