using System;
using Microsoft.Data.SqlClient;
using SIS.Exceptions;
using SIS.Model;
using SIS.util;

namespace SIS.Repository
{
    public class EnrollmentRepository : iEnrollmentRepository


	{

        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public EnrollmentRepository()
        {
            sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();
        }

		public string GetStudent(Enrollment enroll) 
		{

            bool exists = CheckIfEnrollIdExists(enroll);

            if (!exists)
            {
                throw new InvalidEnrollmentDataException("Invalid Data");
            }
            else
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "select concat (s.first_name + ' ' , s.last_name) as Student_Name from Students s JOIN Enrollments e ON s.student_id = e.student_id WHERE enrollment_id = @gid";
                cmd.Parameters.AddWithValue("@gid", enroll.enrollId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                string StudentName = Convert.ToString(cmd.ExecuteScalar());
                sqlConnection.Close();
                return StudentName;
            }
        }

		public string GetCourse(Enrollment enroll) 
		{
            bool exists = CheckIfEnrollIdExists(enroll);

            if (!exists)
            {
                throw new InvalidEnrollmentDataException("Invalid Data");
            }
            else
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT course_name from Courses c JOIN Enrollments e ON c.course_id = e.course_id WHERE enrollment_id = @eid";
                cmd.Parameters.AddWithValue("@eid", enroll.enrollId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                string CName = Convert.ToString(cmd.ExecuteScalar());
                sqlConnection.Close();
                return CName;
            }
        }

        public List<Student> GenerateEnrollReport(Enrollment enroll)
        {
            cmd.Parameters.Clear();
            List<Student> newstu = new List<Student>()
;            cmd.CommandText = "SELECT * FROM Students s JOIN Enrollments e ON e.student_id = s.student_id WHERE course_id = @courid";
            cmd.Parameters.AddWithValue("@courid", enroll.courseId); ;
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Student stu = new Student();
                stu.studentId = (int)reader["student_id"];
                stu.firstName = (string)reader["first_name"];
                stu.lastName = (string)reader["last_name"];
                stu.dob = (DateTime)reader["date_of_birth"];
                stu.email = (string)reader["email"];
                stu.phoneNumber = (string)reader["phone_number"];
                newstu.Add(stu);

            }
            sqlConnection.Close();
            return newstu;
        }


        public List<Course> getallcourse() 
        {
            cmd.Parameters.Clear();
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

        public bool CheckIfEnrollIdExists(Enrollment enroll)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT COUNT(*) FROM Enrollments WHERE enrollment_id = @ei ";
                cmd.Parameters.AddWithValue("@ei", enroll.enrollId);
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





    }

      


        




	
}

