using System;
namespace SIS.Exceptions
{
	public class InvalidEnrollmentDataException : Exception
	{
		public InvalidEnrollmentDataException(string msg) : base(msg)
		{
		}
	}
}

