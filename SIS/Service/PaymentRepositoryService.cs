using System;
using SIS.Exceptions;
using SIS.Model;
using SIS.Repository;

namespace SIS.Service
{
    public class PaymentRepositoryService
    {
        readonly iPaymentRepository _paymentrepository;

        public PaymentRepositoryService()
        {
            _paymentrepository = new PaymentRepository();
        }

        public void GetStudent() 
        {
            try
            {
                Console.WriteLine("~Welcome To Payment Department~");
                Console.WriteLine("~Please Fill below details ~");
                Console.WriteLine("Payment Id");
                int paymentId = int.Parse(Console.ReadLine());
                Student infostudent = _paymentrepository.GetStudent(paymentId);
                Console.WriteLine("Student Id " + infostudent.studentId + " " + "Student Name ::" + infostudent.firstName + " " + infostudent.lastName + "Of Paymed ID" + paymentId);
            }
            catch (PaymentDataException ex)
            {
                Console.WriteLine(ex.Message);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void GetPaymentAmount() 
        {
            try
            {
            Console.WriteLine("~Welcome To Payment Department~");
            Console.WriteLine("~Please Fill below details ~");
            Console.WriteLine("Payment Id");
            int paymentId = int.Parse(Console.ReadLine());

            
            decimal paymentAmount = _paymentrepository.GetPaymentAmount(paymentId);
            if (paymentAmount > 0)
            {
                Console.WriteLine("Payment amount for ID " + paymentId + ": " + paymentAmount);
            }
            }
            catch (PaymentDataException ex)
            {
                Console.WriteLine(ex.Message);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
}

        public void GetPaymentDate() 
        {
            try { 
            Console.WriteLine("~Welcome To Payment Department~");
            Console.WriteLine("~Please Fill below details ~");
            Console.WriteLine("Payment Id");
            int paymentId = int.Parse(Console.ReadLine());

            decimal paymentAmount = _paymentrepository.GetPaymentAmount(paymentId);
            DateTime paymentDate = _paymentrepository.GetPaymentDate(paymentId);
            if (paymentDate != null) 
            {
                Console.WriteLine("Payment date for ID " + paymentId + ": " + "Payment Amount " + ": " + paymentAmount + "Payment Amount " + ": " + paymentDate.ToString("yyyy-MM-dd"));
            }
            }
            catch (PaymentDataException ex)
            {
                Console.WriteLine(ex.Message);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void GeneratePaymentReport()
        {
            Student stuu = new Student();
            Console.WriteLine("~Welcome To Payment Report Creation~");
            List<Student> stu = _paymentrepository.getallstudent();
            foreach (Student s1 in stu)
            {
                Console.WriteLine(
$"Student Id : {s1.studentId} \t " +
$"Name : {s1.firstName} {s1.lastName}"
);
            }


            Console.WriteLine("Select Student Id");
            stuu.studentId = int.Parse(Console.ReadLine());
            List<Payment> abc = _paymentrepository.GeneratePaymentReport(stuu);
            foreach (Payment a in abc)
            {
                Console.WriteLine(a);
            }

        }



    }

}