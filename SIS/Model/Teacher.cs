using System;
namespace SIS.Model
{
	public class Teacher
	{
        int TeacherId;
        string FirstName;
        string LastName;
        string Email;
        string Expertise;
        List<Course> AssignedCourses;


        public List<Course> assignedCourses
        {
            get { return AssignedCourses; } //read only property
            set { AssignedCourses = value; } //write only property
        }

        public int teacherId
        {
            get { return TeacherId; } //read only property
            set { TeacherId = value; } //write only property
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
        public string email
        {
            get { return Email; } //read only property
            set { Email = value; } //write only property
        }
        public string expertise
        {
            get { return Expertise; } //read only property
            set { Expertise = value; } //write only property
        }

        public override string ToString()
        {
            return $"Teacher Id : {teacherId} || First Name : {firstName} || Last Name : {lastName}  || Email : {email} || Expertise : {expertise} ";
        }


        public Teacher(int TeacherId,string FirstName,string LastName,string Email,string Expertise)
		{
            teacherId = TeacherId;
            firstName = FirstName;
            lastName = LastName;
            email = Email;
            expertise = Expertise;
		}

        public Teacher()
        {
 

        }
    }
}

