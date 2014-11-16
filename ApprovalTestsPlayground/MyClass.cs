using System;

namespace ApprovalTestsPlayground
{
	public class MyClass
	{
		public string DoWeirdMath (int a, int b)
		{
			if (b == 0)
				throw new ArgumentException ("Zero for b? You must be kidding me!");

			return (3 * a + 2 * b + a / b - 4).ToString();
		}
	}
}

