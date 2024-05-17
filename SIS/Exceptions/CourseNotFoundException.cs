using System;
namespace SIS.Exceptions
{
	public class CourseNotFoundException : Exception
	{
		public CourseNotFoundException(string msg): base(msg)
		{
		}
	}
}

