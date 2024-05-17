 using System;
namespace SIS.Exceptions
{
	public class PaymentValidationException : Exception
	{
		public PaymentValidationException()
		{
		}

        public PaymentValidationException(string msg) :base(msg)
        {
        }
    }
}

