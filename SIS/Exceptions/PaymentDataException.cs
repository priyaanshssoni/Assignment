using System;
namespace SIS.Exceptions
{
	public class PaymentDataException : Exception
	{
		public PaymentDataException(string msg) : base (msg)
		{
		}
	}
}

