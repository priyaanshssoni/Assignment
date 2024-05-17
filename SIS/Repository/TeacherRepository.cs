using System;
using Microsoft.Data.SqlClient;
using SIS.Exceptions;
using SIS.Model;
using SIS.util;

namespace SIS.Repository
{
    public class TeacherRepository : iTeacherRepository
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        Teacher teacher;


        public TeacherRepository()
        {
            
            sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();
        }


        public int UpdateTeacherInfo(Teacher teacher) 
        {
            bool exists = CheckIfTeacherIdExists(teacher);

            if (!exists)
            {
                throw new TeacherNotFoundException("Invalid teacher ID");
            }
            else
            {

                cmd.CommandText = "UPDATE Teacher SET first_name = @first_name,last_name =@last_name,email =@email,expertise =@expertise WHERE teacher_id = @tid ";
                cmd.Parameters.AddWithValue("@tid", teacher.teacherId);
                cmd.Parameters.AddWithValue("@first_name", teacher.firstName);
                cmd.Parameters.AddWithValue("@last_name", teacher.lastName);
                cmd.Parameters.AddWithValue("@email", teacher.email);
                cmd.Parameters.AddWithValue("@expertise", teacher.expertise);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int updateinfo = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return updateinfo;
            }

        }

        public Teacher DisplayTeacherInfo(Teacher teacher)
        {
            bool exists = CheckIfTeacherIdExists(teacher);

            if (!exists)
            {
                throw new TeacherNotFoundException("Invalid teacher ID");
            }
            else
            {
                cmd.CommandText = "select * from Teacher where teacher_id = @teacher_id";
                cmd.Parameters.AddWithValue("@teacher_id", teacher.teacherId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Teacher teach = new Teacher();
                while (reader.Read())
                {
                    teach.teacherId = (int)(reader["teacher_id"]);
                    teach.firstName = (string)reader["first_name"];
                    teach.lastName = (string)reader["last_name"];
                    teach.email = (string)reader["email"];
                    teach.expertise = (string)reader["expertise"];
                    //   teach.expertise = Convert.ToStringreader["expertise"];
                }
                sqlConnection.Close();
                return teach;
            }

        }


        public List<Course> GetAssignedCourses(Teacher teacher) 
        {
            
            List<Course> course = new List<Course>();

       
            bool exists = CheckIfTeacherIdExists(teacher);

            if (!exists)
            {
                throw new TeacherNotFoundException("Invalid teacher ID");
            }
            else
            {
                cmd.CommandText = "select course_id,course_code,course_name,t.teacher_id from Courses c JOIN Teacher t ON c.teacher_id = t.teacher_id WHERE t.teacher_id = @tid";
                cmd.Parameters.AddWithValue("@tid", teacher.teacherId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Course course1 = new Course();
                    course1.CourseId = (int)reader["course_id"];
                    course1.CourseCode = (string)reader["course_code"]; 
                    course1.CourseName = (string)reader["course_name"];
                    course.Add(course1);

                }
                sqlConnection.Close();
                return course;

            }
        }


        public bool CheckIfTeacherIdExists(Teacher teacher)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT COUNT(*) FROM Teacher WHERE teacher_id = @TeacherId";
            cmd.Parameters.AddWithValue("@TeacherId", teacher.teacherId);
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
                sqlConnection.Close();
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }


        }

       

    }

}

