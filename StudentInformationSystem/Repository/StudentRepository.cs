using System;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using Microsoft.Data.SqlClient;
using StudentInformationSystem;

namespace SIS.Repository

{
	public class StudentRepository : iStudentRepository
	{


        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;


        //
        public StudentRepository()  // it will assign memory
        {
            sqlConnection = new SqlConnection("Server = localhost; Database = SISDB; User Id = sa; Password = reallyStrongPwd123; TrustServerCertificate = True");
            //sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();

        }

        public int AddStudent(Student student)

        {           
            cmd.CommandText = "INSERT INTO Students VALUES(@first_name,@last_name,@date_of_birth,@email,@phone_number)";
            cmd.Parameters.AddWithValue("@first_name",student.firstName);
            cmd.Parameters.AddWithValue("@last_name", student.lastName);
            cmd.Parameters.AddWithValue("@date_of_birth", student.dob);
            cmd.Parameters.AddWithValue("@email", student.email);
            cmd.Parameters.AddWithValue("@phone_number", student.phoneNumber);
            sqlConnection.Open();
            int addStudentStatus = cmd.ExecuteNonQuery();
            
            if(addStudentStatus>0)
            Console.WriteLine("Student Addititon Sucessful");
            sqlConnection.Close();
            return addStudentStatus;

        }


        public int DeleteStudent(Student student)
        {
            
            cmd.CommandText = "DELETE FROM Students where student_id = @student_id)";
            cmd.Parameters.AddWithValue("@student_id", student.studentId);
            sqlConnection.Open();
            int deleteStudentStatus = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return deleteStudentStatus;

        }


        //public int EnrollInCourse(Student student,Course course)
        //{
        //    //clearing paramateres
        //    //cmd.Parameters.Clear()
        //    cmd.CommandText = "INSERT INTO Enrollments VALUES(@student_id,@course_id,@enrollment_date)";
        //    cmd.Parameters.AddWithValue("@student_id", student.studentId);
        //    cmd.Parameters.AddWithValue("@course_id", course.CourseId);
        //    cmd.Parameters.AddWithValue("@enrollment_date",DateTime.Now);
        //    cmd.Connection = sqlConnection;
        //    sqlConnection.Open();
        //    int EnrollStatus = cmd.ExecuteNonQuery();
        //    sqlConnection.Close();
        //    return EnrollStatus;

        //}

        //public int MakePayment(Student student ,Payment payment)
        //{
        //    //clearing paramateres
        //    //cmd.Parameters.Clear
        //    //student.studentid
        //    //
        //    cmd.CommandText = "INSERT INTO Payments VALUES(@student_id,@amount,@payment_date)";
        //    cmd.Parameters.AddWithValue("@student_id", student.studentId);
        //    cmd.Parameters.AddWithValue("@amount", payment.amount);
        //    cmd.Parameters.AddWithValue("@payment_date", DateTime.Now);
        //    cmd.Connection = sqlConnection;
        //    sqlConnection.Open();
        //    int paymentStatus = cmd.ExecuteNonQuery();
        //    sqlConnection.Close();
        //    return paymentStatus;
        //}

        public Student DisplayStudentInfo(Student student)
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

        public int UpdateStudentInfo( Student student)
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

        //public List<Payment> GetPaymentHistory(Student student)
        //{
            
        //    List<Payment> pay = new List<Payment>();
        //    cmd.CommandText = "SELECT * FROM Payments where student_id = @student_id ";
        //    cmd.Parameters.AddWithValue("@student_id", student.studentId);
        //    cmd.Connection = sqlConnection;
        //    sqlConnection.Open();
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        Payment payments = new Payment();
        //        payments.paymentId = (int)reader["payment_id"];
        //        payments.studentId = (int)reader["student_id"];
        //        payments.amount = (int)reader["amount"];
        //        payments.paymentDate = (DateTime)reader["payment_date"];
        //        pay.Add(payments);

        //    }
        //    sqlConnection.Close();
        //    return pay;

        //}

        //public List<Enrollment> GetEnrolledCourses(Student student)
        //{
        //    List<Enrollment> enroll = new List<Enrollment>();
        //    cmd.CommandText = "SELECT * FROM Enrollments where student_id = @student_id ";
        //    cmd.Parameters.AddWithValue("@student_id", student.studentId);
        //    cmd.Connection = sqlConnection;
        //    sqlConnection.Open();
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        Enrollment enrol = new Enrollment();
        //        enrol.enrollId = (int)reader["enrollment_id"];
        //        enrol.courseId = (int)reader["course_id"];
        //        enrol.enrollDate = (DateTime)reader["enrollment_date"];
        //        enroll.Add(enrol);
        //    }
        //    sqlConnection.Close();
        //    return enroll;
        //}


    }



       
    }
