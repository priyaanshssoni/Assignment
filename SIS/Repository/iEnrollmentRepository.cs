using System;
using SIS.Model;

namespace SIS.Repository
{
	

	public interface iEnrollmentRepository
	{

        string GetStudent(Enrollment enroll);
        string GetCourse(Enrollment enroll);
        List<Student> GenerateEnrollReport(Enrollment enroll);
        List<Course> getallcourse();
        bool CheckIfEnrollIdExists(Enrollment enroll);
    }


}

