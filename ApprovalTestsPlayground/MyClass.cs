using System;

namespace ApprovalTestsPlayground
{
	public interface ILog
	{
		void Debug (string message);
		void Error (string message);
	}

	public interface IWebService
	{
		string GetMultiplier ();
	}

	public class MyClass
	{
		public string DoWeirdMath (int a, int b, ILog log, IWebService webService)
		{
			log.Debug ("Entered method...");

			if (b == 0)
				throw new ArgumentException ("Zero for b? You must be kidding me!");

			int multiplier = 0;
			try
			{
				var multiplierText = webService.GetMultiplier ();
				int.TryParse (multiplierText, out multiplier);
			}
			catch (Exception ex)
			{
				log.Error ("Web service call failed. " + ex.ToString ());
			}

			var result = (3 * a + 2 * b + a / b - 4) * multiplier;

			log.Debug("Leaving method...");

			return (result).ToString();
		}
	}
}

