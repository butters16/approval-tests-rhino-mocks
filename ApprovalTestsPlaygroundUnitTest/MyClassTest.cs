using System;
using NUnit.Framework;
using ApprovalTestsPlayground;
using ApprovalTests.Combinations;
using ApprovalTests.Reporters;

namespace ApprovalTestsPlaygroundUnitTest
{
	[TestFixture]
	[UseReporter(typeof(FileLauncherReporter))]
	public class MyClassTest
	{
		[Test]
		public void Test ()
		{
			var sut = new MyClass ();
			var firsts = new[] { -10, -5, 0, 5, 10 };
			var seconds = new[] { -2, -1, 0, 1, 2 };

			CombinationApprovals.VerifyAllCombinations (sut.DoWeirdMath, firsts, seconds);
		}
	}
}

