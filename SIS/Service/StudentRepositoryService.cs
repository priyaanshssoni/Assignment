﻿using System;
using System.Globalization;
using SIS.Exceptions;
using SIS.Model;
using SIS.Repository;

namespace SIS.Service
{
    public class StudentRepositoryService
    {
        readonly iStudentRepository _studentrepo;


        public StudentRepositoryService()
        {
            _studentrepo = new StudentRepository();
        }

        public void AddStudent()
        {
            try
            {
                Student student = new Student();
                Console.WriteLine(
    "~Welcome To Student Addition Department~"
);
                Console.WriteLine(
                    "~Please Fill below details of the Student~"
                );
                Console.WriteLine(" First Name");
                student.firstName = Console.ReadLine();
                Console.WriteLine(" Last Name");
                student.lastName = Console.ReadLine();
                Console.WriteLine(" Date of Birth (format: yyyy-MM-dd)");
                student.dob = Convert.ToDateTime(Console.ReadLine());
             
                Console.WriteLine(" Email ");
                student.email = Console.ReadLine();
                if (!student.email.Contains("@"))
                {
                    throw new InvalidStudentDataException("Invalid email format. Please use the format: abc@example.com");
                    
                }
                

                Console.WriteLine(" Phone Number ");
                student.phoneNumber = (Console.ReadLine());
                if (student.phoneNumber.Length > 10 || student.phoneNumber.Length < 10)
                {
                    throw new InvalidStudentDataException("Phone Number Contains More Than 10 Numbers");
                }


                _studentrepo.AddStudent(student);

            }
            catch(InvalidStudentDataException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }


        public void DeleteStudent()
        {
            try
            {
                Student student = new Student();
                Console.WriteLine("~Welcome To Student Deletion Department~");
                Console.WriteLine("~Please Fill below details of the Student~");
                List<Student> stu = _studentrepo.getallstudent();
                foreach (Student abc in stu)
                {
                    Console.WriteLine(
    $"Student Id : {abc.studentId} \t " +
    $"Name : {abc.firstName} {abc.lastName}"
);
                }
                Console.WriteLine("Student Id");
                student.studentId = Convert.ToInt32(Console.ReadLine());
                _studentrepo.DeleteStudent(student);
            }
            catch (StudentNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }


        }


        public void EnrollInCourse()
        {

            try
            {
                Student student = new Student();
                Course course = new Course();
                Console.WriteLine("~Welcome To Course Enrollment Department~");
                Console.WriteLine("~Please Fill below details of the Student~");
                List<Student> stu = _studentrepo.getallstudent();
                foreach(Student abc in stu)
                {
                    Console.WriteLine(
    $"Student Id : {abc.studentId} \t " +
    $"Name : {abc.firstName} {abc.lastName}"
);
                }
                

                Console.WriteLine("Enter Student Id");
                student.studentId = Convert.ToInt32(Console.ReadLine());

                List<Course> cc = _studentrepo.getallcourse();
                foreach (Course cour in cc)
                {
                    Console.WriteLine(
     $"Course Id : {cour.CourseId} || " +
     $"Course Code : {cour.CourseCode} || " +
     $"Course Name : {cour.CourseName}"
 );
                }
                //List<Course> cc = _studentrepo.getallcourse();
                //foreach (Course cour in cc)
                //{
                //    Console.WriteLine($"Course Id : {cour.CourseId} || Course Code : {cour.CourseCode} ");
                //}

                Console.WriteLine("Select Course Id");
                course.CourseId = Convert.ToInt32(Console.ReadLine());

               int status =  _studentrepo.EnrollInCourse(student, course);
                if (status > 0)
                {
                    Console.WriteLine("Enrollment Succesful");
                }

            }
            catch (StudentNotFoundException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch (CourseNotFoundException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch (DuplicateEnrollmentException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }


            public void MakePayment()
            {

            try
            {
                Student student = new Student();
                Payment pay = new Payment();
                Console.WriteLine("~Welcome To Payments Department~");

                Console.WriteLine("~Please Fill below details ~");
                List<Student> stu = _studentrepo.getallstudent();
                foreach (Student abc in stu)
                {
                    Console.WriteLine(
    $"Student Id : {abc.studentId} \t " +
    $"Name : {abc.firstName} {abc.lastName}"
);
                }
                Console.WriteLine("Student Id");
                student.studentId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Amount");
                pay.amount = Convert.ToInt32(Console.ReadLine());
                if(pay.amount<=0)
                {
                    throw new PaymentValidationException("Invalid Payment Amount");
                }
                Console.WriteLine("Payment Date (dd-MM-Yyyy)");
                pay.paymentDate = Convert.ToDateTime(Console.ReadLine());
                int status = _studentrepo.MakePayment(student, pay);
                if (status > 0)
                {
                    Console.WriteLine("Payment Succesful");
                }
            }
            catch (StudentNotFoundException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch (PaymentValidationException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }


        }

        public void DisplayStudentInfo()
        {
            Student student = new Student();
            Console.WriteLine("~Welcome To Student Information Department~");
            Console.WriteLine("~Please Fill below details of the Student~");
            try
            {
                Console.WriteLine("Student Id");
                student.studentId = Convert.ToInt32(Console.ReadLine());


                Console.WriteLine(_studentrepo.DisplayStudentInfo(student));
            }
            catch (StudentNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }


        }

        public void UpdateStudentInfo() 
        {
            try
            {
                Student student = new Student();
                Console.WriteLine("~Welcome To Student Updatation Department~");
                Console.WriteLine("~Please Fill below details of the Student~");
                List<Student> stu = _studentrepo.getallstudent();
                foreach (Student abc in stu)
                {
                    Console.WriteLine(
    $"Student Id : {abc.studentId} \t " +
    $"Name : {abc.firstName} {abc.lastName}"
);
                }
                Console.WriteLine(" Student Id");
                student.studentId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(" First Name");
                student.firstName = Console.ReadLine();
                Console.WriteLine(" Last Name");
                student.lastName = Console.ReadLine();
                Console.WriteLine(" Date of Birth (format: dd-MM-yyyy)");
                student.dob = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine(" Email ");
                student.email = (Console.ReadLine());
                if (!student.email.Contains("@"))
                {
                    throw new InvalidStudentDataException("Invalid email format. Please use the format: abc@example.com");
                }

                Console.WriteLine(" Phone Number ");
                student.phoneNumber = (Console.ReadLine());
                if (student.phoneNumber.Length > 10 || student.phoneNumber.Length < 10)
                {
                    throw new InvalidStudentDataException("Phone Number Should Contain 10 Digits");
                }


               int status =  _studentrepo.UpdateStudentInfo(student);
                if(status>0)
                { Console.WriteLine( "Student Updation Succesful"); }
            }
            catch (InvalidStudentDataException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void GetPaymentHistory() 
        {
            try
            {
                Student student = new Student();
                Console.WriteLine("~Welcome To Payments Department~");
                Console.WriteLine("~Please Fill below details ~");
                Console.WriteLine("Student Id");
                student.studentId = Convert.ToInt32(Console.ReadLine());
                List<Payment> stu = _studentrepo.GetPaymentHistory(student); ;
                foreach (Payment item in stu)
                {
                    Console.WriteLine(item);
                }
            }
            catch (InvalidStudentDataException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        public void GetEnrolledCourses()
        {
         try
        {
            Student student = new Student();
            Console.WriteLine("~Welcome To Enrollments Department~");
            Console.WriteLine("~Please Fill below details ~");
            Console.WriteLine("Student Id");
            student.studentId = Convert.ToInt32(Console.ReadLine());

            List<Enrollment> stu = _studentrepo.GetEnrolledCourses(student);
            foreach (Enrollment item in stu)
            {
                Console.WriteLine(item);
            }
        }
            catch (InvalidStudentDataException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


    }
}

