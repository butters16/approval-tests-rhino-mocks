using System;
using NUnit.Framework;
using ApprovalTestsPlayground;
using ApprovalTests.Combinations;
using ApprovalTests.Reporters;
using Rhino.Mocks;

namespace ApprovalTestsPlaygroundUnitTest
{
	[TestFixture]
	[UseReporter(typeof(FileLauncherReporter))]
	public class MyClassTest
	{
		public class LogWithToStringOverride : ILog
		{
			public override string ToString ()
			{
				throw new NotImplementedException();
			}

			public virtual void Debug(string message)
			{
				throw new NotImplementedException();
			}
		}

		[Test]
		public void Test ()
		{
			var sut = new MyClass ();
			var firsts = new[] { -10, -5, 0, 5, 10 };
			var seconds = new[] { -2, -1, 0, 1, 2 };
			var mockLog = MockRepository.GenerateMock<LogWithToStringOverride> ();
			mockLog.Stub (x => x.ToString ()).Return ("mock log").Repeat.Any();
			var logs = new[] { mockLog };

			// Act and assert
			CombinationApprovals.VerifyAllCombinations (sut.DoWeirdMath, firsts, seconds, logs);
		}
	}
}

