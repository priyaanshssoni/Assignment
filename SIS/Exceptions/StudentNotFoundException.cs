using System;
namespace SIS.Exceptions
{
	public class StudentNotFoundException : Exception
	{
		public StudentNotFoundException()
		{
		}

        public StudentNotFoundException(string msg): base(msg)
        {
        }


    }
}

