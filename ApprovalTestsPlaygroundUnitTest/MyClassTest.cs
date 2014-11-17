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

			public virtual void Error(string message)
			{
				throw new NotImplementedException();
			}
		}

		public class WebServiceWithToStringOverride : IWebService
		{
			public override string ToString ()
			{
				throw new NotImplementedException();
			}

			public virtual string GetMultiplier ()
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
			var logs = new[] {
				CreateMockLog("mock log")
			};
			var webServices = new[] {
				CreateMockWebServiceReturn ("-10"),
				CreateMockWebServiceReturn ("0"),
				CreateMockWebServiceReturn ("10"),
				CreateMockWebServiceReturn ("something unexpected"),
				CreateMockWebServiceReturn (null),
				CreateMockWebServiceException ("some exception")
			};

			// Act and assert
			CombinationApprovals.VerifyAllCombinations (sut.DoWeirdMath, firsts, seconds, logs, webServices);
		}

		private static LogWithToStringOverride CreateMockLog (string toString)
		{
			var mockLog = MockRepository.GenerateMock<LogWithToStringOverride> ();
			StubToString (mockLog, toString);
			mockLog.Stub (x => x.ToString ()).Return (toString);
			return mockLog;
		}

		private static WebServiceWithToStringOverride CreateMockWebServiceReturn (string result)
		{
			var mockWebService = MockRepository.GenerateMock<WebServiceWithToStringOverride> ();
			StubToString (mockWebService, result);
			mockWebService.Stub (x => x.GetMultiplier ()).Return (result);
			return mockWebService;
		}

		private static WebServiceWithToStringOverride CreateMockWebServiceException (string message)
		{
			var mockWebService = MockRepository.GenerateMock<WebServiceWithToStringOverride> ();
			StubToString (mockWebService, message);
			mockWebService.Stub (x => x.GetMultiplier ()).Throw(new Exception(message));
			return mockWebService;
		}

		private static void StubToString(object obj, string toString)
		{
			var nonNullToString = toString == null ? "null" : toString;
			obj.Stub (x => x.ToString ()).Return (nonNullToString);
		}
	}
}

