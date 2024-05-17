using System;
namespace StudentInformationSystem
{
	public class Student
	{

        int StudentId;
        string FirstName;
        string LastName;
        DateTime Dob;
        string Email;
        string PhoneNumber;



        public int studentId
        {
            get { return StudentId; } //read only property
            set { StudentId = value; } //write only property
        }

        public string firstName
        {
            get { return FirstName; } //read only property
            set { FirstName = value; } //write only property
        }

        public string lastName
        {
            get { return LastName; } //read only property
            set { LastName = value; } //write only property
        }

        public DateTime dob
        {
            get { return Dob; } //read only property
            set { Dob = value; } //write only property
        }

        public string email
        {
            get { return Email; } //read only property
            set { Email = value; } //write only property
        }

        public string phoneNumber
        {
            get { return PhoneNumber; } //read only property
            set { PhoneNumber = value; } //write only property
        }


        public Student()
        {

        }

        public Student(int StudentId, string FirstName, string LastName,
        DateTime Dob, string Email, string PhoneNumber)
        {
            studentId = StudentId;
            firstName = FirstName;
            lastName = LastName;
            dob = Dob;
            email = Email;
            phoneNumber = PhoneNumber;
        }
    }
}



