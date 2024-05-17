using System;
namespace SIS.Exceptions
{
	public class TeacherNotFoundException :Exception
	{
		public TeacherNotFoundException()
		{
		}

        public TeacherNotFoundException(string msg) : base(msg)
        {
        }
    }
}

