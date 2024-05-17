using System;

namespace StudentInformationSystem
{
	public interface iStudentRepository
	{

        int AddStudent(Student student);

        int DeleteStudent(Student student);

    //    int EnrollInCourse(Student student, Course course);

        int UpdateStudentInfo(Student student);

   //     int MakePayment(Student student,Payment payment);

        Student DisplayStudentInfo(Student student);

    //    List<Enrollment> GetEnrolledCourses(Student student);

     //   List<Payment> GetPaymentHistory(Student student);
    }
}

