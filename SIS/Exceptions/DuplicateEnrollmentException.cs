using System;
namespace SIS.Exceptions
{
	public class DuplicateEnrollmentException : Exception
	{
		public DuplicateEnrollmentException()
		{
		}

        public DuplicateEnrollmentException(string msg) : base(msg)
        {
        }
    }
}

