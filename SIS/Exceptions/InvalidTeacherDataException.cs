using System;
namespace SIS.Exceptions
{
	public class InvalidTeacherDataException : Exception
	{
		public InvalidTeacherDataException(string msg): base (msg)
		{
		}
	}
}

