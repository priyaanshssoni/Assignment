using System;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using Microsoft.Data.SqlClient;
using SIS.Exceptions;
using SIS.Model;
using SIS.util;

namespace SIS.Repository

{
    public class StudentRepository : iStudentRepository
    {


        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;


        
        public StudentRepository()
        {
       
            sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();

        }

        public int AddStudent(Student student) 

        {
            cmd.CommandText = "INSERT INTO Students VALUES(@first_name,@last_name,@date_of_birth,@email,@phone_number)";
            cmd.Parameters.AddWithValue("@first_name", student.firstName);
            cmd.Parameters.AddWithValue("@last_name", student.lastName);
            cmd.Parameters.AddWithValue("@date_of_birth", student.dob);
            cmd.Parameters.AddWithValue("@email", student.email);
            cmd.Parameters.AddWithValue("@phone_number", student.phoneNumber);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int addStudentStatus = cmd.ExecuteNonQuery();

            if (addStudentStatus > 0)
                Console.WriteLine("Student Addititon Sucessful");

            else
                Console.WriteLine("Student Addititon UnSucessful");

            sqlConnection.Close();
            return addStudentStatus;

        }


        public int DeleteStudent(Student student) 
        {

            bool exists = CheckIfStudentIdExists(student);

            if (!exists)
            {
                throw new StudentNotFoundException("Invalid Student ID");
            }
            else
            {

                cmd.CommandText = "DELETE FROM Students where student_id = @student_id";
                cmd.Parameters.AddWithValue("@student_id", student.studentId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int deleteStudentStatus = cmd.ExecuteNonQuery();
                if (deleteStudentStatus > 0)
                    Console.WriteLine("Student Deletion Sucessful");
                sqlConnection.Close();
                return deleteStudentStatus;
            }

        }


        public int EnrollInCourse(Student student, Course course) 
        {


            bool exists = CheckIfStudentIdExists(student);

            if (!exists)
            {
                throw new StudentNotFoundException("Invalid Student ID");
            }
            else
            {
                bool exists2 = CourseNotFound(course);
                if (!exists2)
                {
                    throw new CourseNotFoundException("Invalid Coursse ID | Course Not Found");
                }
                else
                {
                    bool exists1 = DuplicateEnrollment(student, course);
                    if (exists1)
                    {
                        throw new DuplicateEnrollmentException("Student Already Enrolled In This Course");
                    }
                    else
                    {

                        cmd.CommandText = "INSERT INTO Enrollments VALUES(@student_id,@course_id,@enrollment_date)";
                        cmd.Parameters.AddWithValue("@student_id", student.studentId);
                        cmd.Parameters.AddWithValue("@course_id", course.CourseId);
                        cmd.Parameters.AddWithValue("@enrollment_date", DateTime.Now);
                        cmd.Connection = sqlConnection;
                        sqlConnection.Open();
                        int EnrollStatus = cmd.ExecuteNonQuery();
                        sqlConnection.Close();
                        return EnrollStatus;
                    }
                }

            }
        }

        public int MakePayment(Student student, Payment payment) 
        {
            //clearing paramateres
            //cmd.Parameters.Clear
            //student.studentid
            //

            bool exists = CheckIfStudentIdExists(student);

            if (!exists)
            {
                throw new StudentNotFoundException("Invalid Student ID");
            }
            else
            {
                cmd.CommandText = "INSERT INTO Payments(student_id,amount,payment_date) VALUES(@student_id,@amount,@payment_date)";
                cmd.Parameters.AddWithValue("@student_id", student.studentId);
                cmd.Parameters.AddWithValue("@amount", payment.amount);
                cmd.Parameters.AddWithValue("@payment_date", payment.paymentDate);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int paymentStatus = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return paymentStatus;
            }
        }


        public Student DisplayStudentInfo(Student student) 
        {

            bool exists = CheckIfStudentIdExists(student);

            if (!exists)
            {
                throw new StudentNotFoundException("Invalid Student ID");
            }
            else
            {
                cmd.CommandText = "SELECT * FROM Students where student_id = @student_id";
                cmd.Parameters.AddWithValue("@student_id", student.studentId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    student.studentId = (int)reader["student_id"];
                    student.firstName = (string)reader["first_name"];
                    student.lastName = (string)reader["last_name"];
                    student.dob = (DateTime)reader["date_of_birth"];
                    student.email = (string)reader["email"];
                    student.phoneNumber = (string)reader["phone_number"];


                }
                sqlConnection.Close();
                return student;
            }
        }

        public int UpdateStudentInfo(Student student) 
        {

            bool exists = CheckIfStudentIdExists(student);

            if (!exists)
            {
                throw new StudentNotFoundException("Invalid Student ID");
            }
            else
            {
                cmd.CommandText = "UPDATE Students SET first_name = @first_name,last_name =@last_name,date_of_birth =@date_of_birth,email =@email,phone_number=@phone_number  WHERE student_id = @student_id ";
                cmd.Parameters.AddWithValue("@first_name", student.firstName);
                cmd.Parameters.AddWithValue("@last_name", student.lastName);
                cmd.Parameters.AddWithValue("@date_of_birth", student.dob);
                cmd.Parameters.AddWithValue("@email", student.email);
                cmd.Parameters.AddWithValue("@phone_number", student.phoneNumber); //why string???????
                cmd.Parameters.AddWithValue("@student_id", student.studentId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int updateinfo = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return updateinfo;


            }
        }

        public List<Payment> GetPaymentHistory(Student student) 
        {
            bool exists = CheckIfStudentIdExists(student);

            if (!exists)
            {
                throw new StudentNotFoundException("Invalid Student ID");
            }
            else
            {

                List<Payment> pay = new List<Payment>();
                cmd.CommandText = "SELECT * FROM Payments where student_id = @student_id ";
                cmd.Parameters.AddWithValue("@student_id", student.studentId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Payment payments = new Payment();
                    payments.paymentId = (int)reader["payment_id"];
                    payments.studentId = (int)reader["student_id"];
                    payments.amount = (int)reader["amount"];
                    payments.paymentDate = (DateTime)reader["payment_date"];
                    pay.Add(payments);

                }
                sqlConnection.Close();
                return pay;
            }

        }

        public List<Enrollment> GetEnrolledCourses(Student student) 
        {
            bool exists = CheckIfStudentIdExists(student);

            if (!exists)
            {
                throw new StudentNotFoundException("Invalid Student ID");
            }
            else
            {
                List<Enrollment> enroll = new List<Enrollment>();
                cmd.CommandText = "SELECT * FROM Enrollments where student_id = @student_id ";
                cmd.Parameters.AddWithValue("@student_id", student.studentId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Enrollment enrol = new Enrollment();
                    enrol.enrollId = (int)reader["enrollment_id"];
                    enrol.courseId = (int)reader["course_id"];
                    enrol.enrollDate = (DateTime)reader["enrollment_date"];
                    enroll.Add(enrol);
                }
                sqlConnection.Close();
                return enroll;
            }

        }

        public bool CheckIfStudentIdExists(Student student)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT COUNT(*) FROM Students WHERE student_id = @st ";
            cmd.Parameters.AddWithValue("@st", student.studentId);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                sqlConnection.Close();
                return count > 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine("An error occurred: " + ex.Message);
                
                return false;
            }

        }

        public bool DuplicateEnrollment(Student student, Course course)
        {
           
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT COUNT(*) FROM Enrollments WHERE student_id = @stid AND course_id = @cuid";
            cmd.Parameters.AddWithValue("@stid", student.studentId);
            cmd.Parameters.AddWithValue("@cuid", course.CourseId);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
           try
           {

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                sqlConnection.Close();

                return (count > 0);
              


            }
            catch (Exception ex)
            {

                Console.WriteLine("An error occurred: " + ex.Message);
                
                return false;
                
            }

        }

        public bool CourseNotFound(Course course)
        {
            //clearing paramateres
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT COUNT(*) FROM Courses WHERE course_id = @cnf";
            cmd.Parameters.AddWithValue("@cnf", course.CourseId);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            try
            {

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                sqlConnection.Close();
                return count > 0;


            }
            catch (Exception ex)
            {

                Console.WriteLine("An error occurred: " + ex.Message);
               
                return false;

            }
        }

            public List<Student> getallstudent() //formatting left otherwise working
            {
                List<Student> Stu = new List<Student>();
                cmd.CommandText = "SELECT * FROM Students";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student s1 = new Student();
                    s1.studentId = (int)reader["student_id"];
                    s1.firstName = (string)reader["first_name"];
                    s1.lastName = (string)reader["last_name"];
                    s1.dob = (DateTime)reader["date_of_birth"];
                    s1.email = (string)reader["email"];
                    s1.phoneNumber = (string)reader["phone_number"];
                    Stu.Add(s1);
                }
                sqlConnection.Close();
                return Stu;
            }

        public List<Course> getallcourse() //formatting left otherwise working
        {
            List<Course> cu = new List<Course>();
            cmd.CommandText = "SELECT * FROM Courses";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Course c1 = new Course();
                c1.CourseId = (int)reader["course_id"];
                c1.CourseCode = (string)reader["course_code"];
                c1.CourseName = (string)reader["course_name"];
               
                cu.Add(c1);
            }
            sqlConnection.Close();
            return cu;
        }


    }









        //public bool DisplayStudentInfo()
        //{
        //    throw new NotImplementedException();
        //}

        //public bool EnrollInCourse()
        //{
        //    throw new NotImplementedException();
        //}

        //public bool GetEnrolledCourses()
        //{
        //    throw new NotImplementedException();
        //}

        //public bool GetPaymentHistory()
        //{
        //    throw new NotImplementedException();
        //}

        //public bool MakePayment()
        //{
        //    throw new NotImplementedException();
        //}

        //public bool UpdateStudentInfo()
        //{
        //    throw new NotImplementedException();
        //}
    

}