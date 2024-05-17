using System;
using Microsoft.Data.SqlClient;
using SIS.Exceptions;
using SIS.Model;
using SIS.util;

namespace SIS.Repository
{
    public class PaymentRepository : iPaymentRepository
    {

        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;




        public PaymentRepository()
        {
            
            sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();
        }

        public Student GetStudent(int paymentId)
        {

            bool exists = CheckPayIdExists(paymentId);

            if (!exists)
            {
                throw new PaymentDataException("Invalid Payment ID");
            }
            else
            {
                Student student = new Student();
                cmd.CommandText = "SELECT s.student_id, s.first_name, s.last_name FROM Students s JOIN Payments p ON s.student_id = p.student_id WHERE p.payment_id = @pid";
                cmd.Parameters.AddWithValue("@pid", paymentId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    student.studentId = (int)reader["student_id"];
                    student.firstName = (string)reader["first_name"];
                    student.lastName = (string)reader["last_name"];

                }
                sqlConnection.Close();
                return student;
            }
        }

        public decimal GetPaymentAmount(int paymentId)
        {

            bool exists = CheckPayIdExists(paymentId);

            if (!exists)
            {
                throw new PaymentDataException("Invalid Payment ID");
            }
            else
            {
                
                cmd.CommandText = "SELECT amount FROM Payments WHERE payment_id = @pid";
                cmd.Parameters.AddWithValue("@pid", paymentId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                decimal amount = Convert.ToDecimal(cmd.ExecuteScalar());
                sqlConnection.Close();
                return amount;
            }
        }


        public DateTime GetPaymentDate(int paymentId)
        {

            bool exists = CheckPayIdExists(paymentId);

            if (!exists)
            {
                throw new PaymentDataException("Invalid Payment ID");
            }
            else
            {
               
                cmd.CommandText = "SELECT payment_date FROM Payments WHERE payment_id = @cid";
                cmd.Parameters.AddWithValue("@cid", paymentId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                DateTime paymentDate = (DateTime)cmd.ExecuteScalar();
                sqlConnection.Close();
                return paymentDate;
            }
        }


        public List<Payment> GeneratePaymentReport(Student student)
        {
            cmd.Parameters.Clear();
            List<Payment> newpy= new List<Payment>()
; cmd.CommandText = "SELECT * FROM Payments where student_id = @st1";
            cmd.Parameters.AddWithValue("@st1", student.studentId); ;
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Payment pay = new Payment();
                pay.paymentId = (int)reader["student_id"];
                pay.studentId = (int)reader["student_id"];
                pay.amount = (int)reader["amount"];
                pay.paymentDate = (DateTime)reader["payment_date"];
               
                newpy.Add(pay);

            }
            sqlConnection.Close();
            return newpy;
        }

        public List<Student> getallstudent() 
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


        public bool CheckPayIdExists(int pay)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT COUNT(*) FROM Payments WHERE payment_id = @st ";
                cmd.Parameters.AddWithValue("@st", pay);
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

