using System;
namespace SIS.Exceptions
{
	public class InsufficientFundsException : Exception
	{
		public InsufficientFundsException(string msg): base(msg)
		{
		}
	}
}

