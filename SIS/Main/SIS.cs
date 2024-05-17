using System;
using SIS.Service;

namespace SIS.Main
{
	public class SIS
	{

   

        readonly StudentRepositoryService _studentrepo;
        readonly EnrollmentRepositoryService _enrollmentrepo;
        readonly PaymentRepositoryService _paymentrepo;
        readonly TeacherRepositoryService _teacherrepo;
        readonly CourseRepositoryService _courserepo;


        public SIS(StudentRepositoryService studentrepo, EnrollmentRepositoryService enrollmentrepo, PaymentRepositoryService paymentrepo,
            TeacherRepositoryService teacherrepo, CourseRepositoryService courserepo)
        {
            _studentrepo = studentrepo;

            _enrollmentrepo = enrollmentrepo;
            _paymentrepo = paymentrepo;
            _teacherrepo = teacherrepo;
            _courserepo = courserepo;


        }
        public void run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("~WELCOME TO STUDENT INFORMATION SYSTEM~");
                Console.WriteLine("1) STUDENT SERVICES");
                Console.WriteLine("2) COURSES SERVICES");
                Console.WriteLine("3) TEACHER  SERVICES");
                Console.WriteLine("4) ENROLLMENT SERVICES");
                Console.WriteLine("5) PAYMENT SERVICES");
                Console.WriteLine("0 TO EXIT");
                Console.WriteLine("ENTER YOUR CHOICE");
                int useriput = int.Parse(Console.ReadLine());

                switch (useriput)
                {
                    case 1:
                        ManageStudents();
                        break;
                    case 2:
                        ManageCourses();
                        break;

                    case 3:
                        ManageTeacher();
                        break;

                    case 4:
                        ManageEnrollment();
                        break;
                    case 5:
                        ManagePayment();
                        break;
                    case 0:
                        exit = true;
                        Console.WriteLine("Exited");
                        break;
                    default:
                        Console.WriteLine("ENTER CORRECT INPUT ");
                        break;
                }




            }
        }
        private void ManageStudents()
        {
            Console.WriteLine("STUDENT SERVICE MENU");
            Console.WriteLine("1) ENROLL IN COURSE");
            Console.WriteLine("2) UPDATE STUDENT INFO");

            Console.WriteLine("3) MAKE PAYMENT");

            Console.WriteLine("4) ISPLAY STUDENT INFO");
            Console.WriteLine("5) GET ENROLLED COURSES");
            Console.WriteLine("6) GET PAYMENT HISTORY ");

            int userinput = int.Parse(Console.ReadLine());

            switch (userinput)
            {
                case 1:
                    _studentrepo.EnrollInCourse();
                    break;
                case 2:
                    _studentrepo.UpdateStudentInfo();
                    break;
                case 3:
                    _studentrepo.MakePayment();
                    break;
                case 4:
                    _studentrepo.DisplayStudentInfo();
                    break;
                case 5:
                    _studentrepo.GetEnrolledCourses();
                    break;
                case 6:
                    _studentrepo.GetPaymentHistory();
                    break;
                default:
                    Console.WriteLine("ENTER CORRECT DETAILS ");
                    break;
            }
        }

        private void ManageCourses()
        {
            Console.WriteLine("COURSES SERVICE MENU");
            Console.WriteLine("1) ASSIGN TEACHER");
            Console.WriteLine("2) UPDATE COURSE INFO");

            Console.WriteLine("3) DISPLAY COURSE INFO");

            Console.WriteLine("4) GET ENROLLMENTS");

            Console.WriteLine("5) GET TEACHER DETAILS ");

            int userinput = int.Parse(Console.ReadLine());

            switch (userinput)
            {
                case 1:
                    _courserepo.AssignTeacher();
                    break;
                case 2:
                    _courserepo.UpdateCourseInfo();
                    break;
                case 3:
                    _courserepo.DisplayCourseInfo();
                    
                    break;
                case 4:
                    _courserepo.GetEnrollments();
                    break;
                case 5:
                    _courserepo.GetTeacher();
                    
                    break;

                default:
                    Console.WriteLine("ENTER CORRECT DETAILS ");
                    break;
            }



        }
        private void ManageTeacher()
        {
            Console.WriteLine("TEACHER SERVICE MENU");
            Console.WriteLine("1) UPDATE TEACHER INFO");


            Console.WriteLine("2) DISPLAY TEACHER INFO");

            Console.WriteLine("3) GET ASSIGNED COURSES");



            int userinput = int.Parse(Console.ReadLine());

            switch (userinput)
            {
                case 1:
                    _teacherrepo.UpdateTeacherInfo();
                    break;
                case 2:
                    _teacherrepo.DisplayTeacherInfo();
                    break;
                case 3:
                    _teacherrepo.GetAssignedCourses();
                    break;


                default:
                    Console.WriteLine("ENTER CORRECT DETAILS ");
                    break;
            }



        }
        private void ManageEnrollment()
        {
            Console.WriteLine("ENROLLMENT SERVICE MENU");
            Console.WriteLine("1) GET STUDENT ASSOCIATED WITH ENROLLMENT");


            Console.WriteLine("2) GET ENROLLED COURSE");




            int userinput = int.Parse(Console.ReadLine());

            switch (userinput)
            {
                case 1:
                    _enrollmentrepo.GetStudent();
                    break;
                case 2:
                    _enrollmentrepo.GetCourse();
                    break;



                default:
                    Console.WriteLine("ENTER CORRECT DETAILS ");
                    break;
            }



        }
        private void ManagePayment()
        {
            Console.WriteLine("PAYMENT SERVICE MENU");
            Console.WriteLine("1) GET STUDENT ASSOCIATED WITH PAYMENT");


            Console.WriteLine("2) GET PAYMENT AMOUNT");
            Console.WriteLine("3) GET PAYMENT DATE");




            int userinput = int.Parse(Console.ReadLine());

            switch (userinput)
            {
                case 1:
                    _paymentrepo.GetStudent();
                    break;
                case 2:
                    _paymentrepo.GetPaymentAmount();
                    break;
                case 3:
                    _paymentrepo.GetPaymentDate();
                    break;



                default:
                    Console.WriteLine("ENTER CORRECT DETAILS ");
                    break;
            }



        }



        public SIS()
		{
		}
	}
}

