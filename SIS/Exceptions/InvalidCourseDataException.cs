using System;
namespace SIS.Exceptions
{
	public class InvalidCourseDataException : Exception
	{

        public InvalidCourseDataException( ) 
		{
		}
    public InvalidCourseDataException(string msg) : base(msg)
		{
		}
	}
}

