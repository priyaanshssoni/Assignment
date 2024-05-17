using System;
using Microsoft.Data.SqlClient;
using SIS.Model;

namespace SIS.Repository
{
	public interface iPaymentRepository
	{
         Student GetStudent(int paymentId);
         decimal GetPaymentAmount(int paymentId);
         DateTime GetPaymentDate(int paymentId);
        public List<Payment> GeneratePaymentReport(Student student);
        public List<Student> getallstudent(); 
        public bool CheckPayIdExists(int pay);



    }
}

