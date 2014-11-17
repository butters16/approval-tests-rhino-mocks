using System;

namespace ApprovalTestsPlayground
{
	public interface ILog
	{
		void Debug (string message);
		new string ToString ();
	}

	public class MyClass
	{
		public string DoWeirdMath (int a, int b, ILog log)
		{
			log.Debug ("Entered method...");

			if (b == 0)
				throw new ArgumentException ("Zero for b? You must be kidding me!");

			var result = 3 * a + 2 * b + a / b - 4;

			log.Debug("Leaving method...");

			return (result).ToString();
		}
	}
}

