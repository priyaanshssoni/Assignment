using System;
using System.Globalization;
using SIS.Repository;
using StudentInformationSystem;

namespace StudentInformationSystem
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
                Student student = new Student();
                Console.WriteLine("~Welcome To Student Addition Department~");
                Console.WriteLine("~Please Fill below details of the Student~");
                Console.WriteLine(" First Name");
                student.firstName = Console.ReadLine();
                Console.WriteLine(" Last Name");
                student.lastName = Console.ReadLine();
                Console.WriteLine(" Date of Birth (format: dd-MM-yyyy)");
                student.dob  = Convert.ToDateTime(Console.ReadLine());
                //DateTime truedate;
                //if (!DateTime.TryParseExact(dob_date, "dd-MM-yyyy", null, DateTimeStyles.None, out truedate))

                //    throw new InvalidStudentDataException("Invalid date of birth format. Please use the format: dd-MM-yyyy.");

                //else

                //    student.dob = Convert.ToDateTime(dob_date);

                ////datetime.parse

                Console.WriteLine(" Email ");
                 student.email = Console.ReadLine();
                //if (!student.email.Contains("@"))
                //{
                //    throw new InvalidStudentDataException("Invalid email format. Please use the format: abc@example.com");
                //}

                Console.WriteLine(" Phone Number ");
                student.phoneNumber = (Console.ReadLine());
                //if (student.phoneNumber.Length > 10)
                //{
                //    throw new InvalidStudentDataException("Phone Number Contains More Than 10 Numbers");
                //}


                _studentrepo.AddStudent(student);
        }


        public void DeleteStudent()
        {
            Student student = new Student();
            Console.WriteLine("~Welcome To Student Deletion Department~");
            Console.WriteLine("~Please Fill below details of the Student~");
            Console.WriteLine("Student Id");
            student.studentId = Convert.ToInt32(Console.ReadLine());
            _studentrepo.DeleteStudent(student);

        }


        //public void EnrollInCourse()
        //{
        //    Student student = new Student();
        //    Course course = new Course();
        //    Console.WriteLine("~Welcome To Course Enrollment Department~");
        //    Console.WriteLine("~Please Fill below details of the Student~");
        //    Console.WriteLine("Student Id");
        //    student.studentId = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("Course Id");
        //    course.CourseId = Convert.ToInt32(Console.ReadLine());

        //    _studentrepo.EnrollInCourse(student,course);

        //}



        //public void MakePayment()
        //{
        //    Student student = new Student();
        //    Payment pay = new Payment();
        //    Console.WriteLine("~Welcome To Payments Department~");
        //    Console.WriteLine("~Please Fill below details ~");
        //    Console.WriteLine("Student Id");
        //    student.studentId = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("Amount");
        //    pay.amount = Convert.ToInt32(Console.ReadLine());

        //    _studentrepo.MakePayment(student, pay);

        //}

        public void DisplayStudentInfo()
        {
            Student student = new Student();
            Console.WriteLine("~Welcome To Student Information Department~");
            Console.WriteLine("~Please Fill below details of the Student~");
            Console.WriteLine("Student Id");
            student.studentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(_studentrepo.DisplayStudentInfo(student));

        }

        public void UpdateStudentInfo()
        {
            Student student = new Student();
            Console.WriteLine("~Welcome To Student Updatation Department~");
            Console.WriteLine("~Please Fill below details of the Student~");
            Console.WriteLine(" First Name");
            student.firstName = Console.ReadLine();
            Console.WriteLine(" Last Name");
            student.lastName = Console.ReadLine();
            Console.WriteLine(" Date of Birth (format: dd-MM-yyyy)");
            var dob_date = (Console.ReadLine());
            //DateTime truedate;
            //if (!DateTime.TryParseExact(dob_date, "dd-MM-yyyy", null, DateTimeStyles.None, out truedate))

            //    throw new InvalidStudentDataException("Invalid date of birth format. Please use the format: dd-MM-yyyy.");

            //else

                student.dob = Convert.ToDateTime(dob_date);

            Console.WriteLine(" Email ");
            student.email = Console.ReadLine();
            //if (!student.email.Contains("@"))
            //{
            //    throw new InvalidStudentDataException("Invalid email format. Please use the format: abc@example.com");
            //}

            Console.WriteLine(" Phone Number ");
            student.phoneNumber = (Console.ReadLine());
            //if (student.phoneNumber.Length > 10)
            //{
            //    throw new InvalidStudentDataException("Phone Number Contains More Than 10 Numbers");
            //}


            _studentrepo.UpdateStudentInfo(student);
        }

        //public void GetPaymentHistory()
        //{
        //    Student student = new Student();
        //    Console.WriteLine("~Welcome To Payments Department~");
        //    Console.WriteLine("~Please Fill below details ~");
        //    Console.WriteLine("Student Id");
        //    student.studentId = Convert.ToInt32(Console.ReadLine());
        //    _studentrepo.GetPaymentHistory(student);
        //}


        //public void GetEnrolledCourses()
        //{
        //    Student student = new Student();
        //    Console.WriteLine("~Welcome To Enrollments Department~");
        //    Console.WriteLine("~Please Fill below details ~");
        //    Console.WriteLine("Student Id");
        //    student.studentId = Convert.ToInt32(Console.ReadLine());
        //    _studentrepo.GetEnrolledCourses(student);
        //}


    }
}

