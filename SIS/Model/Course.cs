using System;
namespace SIS.Model
{
	public class Course
	{
	    int courseId;
		string courseName;
		string courseCode;
        string instructorName;
        List<Enrollment> Enrollments;


        public int CourseId
        {
            get { return courseId; } //read only property
            set { courseId = value; } //write only property
        }

        public string CourseName
        {
            get { return courseName; } //read only property
            set { courseName = value; } //write only property
        }

        public string CourseCode
        {
            get { return courseCode; } //read only property
            set { courseCode = value; } //write only property
        }

        public string InstructorName
        {
            get { return instructorName; } //read only property
            set { instructorName = value; } //write only property
        }

        public List<Enrollment> enrollments
        {
            get { return Enrollments; } //read only property
            set { Enrollments = value; } //write only property
        }

        public override string ToString()
        {
            return $"Course Id : {CourseId} || Course Name : {CourseName} || Course Name : {CourseCode} ||  Instructor Name : {InstructorName}";
        }

        public Course()
        {

        }
        public Course(int CourseId,
        string CourseName,
        string CourseCode,
        string InstructorName)
        {
            courseId = CourseId;
            courseName = CourseName;
            courseCode = CourseCode;
            instructorName = InstructorName;
        }

    }
}

