using System;
using SIS.Model;

namespace SIS.Repository
{
	public interface iStudentRepository
	{

        int AddStudent(Student student);

        int DeleteStudent(Student student);

        int EnrollInCourse(Student student, Course course);

        int UpdateStudentInfo(Student student);

        int MakePayment(Student student,Payment payment);

        Student DisplayStudentInfo(Student student);

        List<Enrollment> GetEnrolledCourses(Student student);

        List<Payment> GetPaymentHistory(Student student);

        bool CheckIfStudentIdExists(Student student);

        bool CourseNotFound(Course course);

        bool DuplicateEnrollment(Student student, Course course);

        List<Student> getallstudent();
        List<Course> getallcourse();
    }
}

