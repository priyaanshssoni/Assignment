using System;
namespace SIS.Exceptions
{
	public class InvalidStudentDataException : Exception
	{
		public InvalidStudentDataException()
		{
		}

        public InvalidStudentDataException(string msg) : base(msg)
        {
        }
    }
}

