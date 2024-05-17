using System;
namespace SIS.Model
{
	public class Enrollment
    {

        int EnrollId;
        int StudentId;
        int CourseId;
        DateTime EnrollDate;
        Student Student;
        Course Course;

        public Student student
        {
            get { return Student; } //read only property
            set { Student = value; } //write only property
        }

        public Course course
        {
            get { return Course; } //read only property
            set { Course = value; } //write only property
        }


        public int enrollId
        {
            get { return EnrollId; } //read only property
            set { EnrollId = value; } //write only property
        }

        public int studentId
        {
            get { return StudentId; } //read only property
            set { StudentId = value; } //write only property
        }

        public int courseId
        {
            get { return CourseId; } //read only property
            set { CourseId = value; } //write only property
        }

        public DateTime enrollDate
        {
            get { return EnrollDate; } //read only property
            set { EnrollDate = value; } //write only property
        }

        public override string ToString()
        {
            return $"Enrollment Id : {enrollId} || Course Id : {courseId} || Enrollment Date : {enrollDate} ";
        }


        public Enrollment()
        {

        }

        public Enrollment( int EId,int StudentId,int CourseId,DateTime EnrollDate)
		{
            enrollId = EId;
            studentId = StudentId;
            courseId = CourseId;
            enrollDate = EnrollDate;
           

		}
	}
}

