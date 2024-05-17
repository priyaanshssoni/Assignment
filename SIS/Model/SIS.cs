using System;
using System.Collections.Generic;

namespace SIS.Model
{
	public class SIS
	{

     private readonly List<Student> _students;
     private readonly List<Course> _courses;
     private readonly List<Teacher> _teachers;
     private readonly List<Enrollment> _enrollments;
     private readonly List<Payment> _payments;





        public SIS()
		{
            _students = new List<Student>();
            _courses = new List<Course>();
            _enrollments = new List<Enrollment>();
            _teachers = new List<Teacher>();
            _payments = new List<Payment>();
        }
	}
}

