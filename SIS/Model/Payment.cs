using System;
namespace SIS.Model
{
	public class Payment
	{

        int PaymentId;
        int StudentId;
        decimal Amount;
        DateTime PaymentDate;
        Student Student;

        public Student student
        {
            get { return Student; } //read only property
            set { Student = value; } //write only property
        }

        public int paymentId
        {
            get { return PaymentId; } //read only property
            set { PaymentId = value; } //write only property
        }
        public int studentId
        {
            get { return StudentId; } //read only property
            set { StudentId = value; } //write only property
        }
        public decimal amount
        {
            get { return Amount; } //read only property
            set { Amount = value; } //write only property
        }
        public DateTime paymentDate
        {
            get { return PaymentDate; } //read only property
            set { PaymentDate = value; } //write only property


        }

        public override string ToString()
        {
            return $"Payment Id : {paymentId} || Amount: {Amount} || PaymentDate : {paymentDate} ";
        }


        public Payment()
        {

        }

        public Payment(int PaymentId,int StudentId,decimal Amount,DateTime PaymentDate)
		{
            paymentId = PaymentId;
            studentId = StudentId;
            amount = Amount;
            paymentId = PaymentId;
		}
	}
}

