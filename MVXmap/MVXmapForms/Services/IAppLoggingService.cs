using System;
using MvvmCross.Platform;

namespace MVXmapForms
{

	public interface IAppLoggingService
	{
		void Warning(string message, params object[] args);
		void Debug(string message, params object[] args);
		void Error(string message, params object[] args);
	}

	public class AppLoggingService : IAppLoggingService
	{
		readonly string _tag = "MVXmap";

		public void Warning(string message, params object[] args)
		{
			Mvx.TaggedWarning(_tag, message, args);
		}

		public void Debug(string message, params object[] args)
		{
			Mvx.TaggedTrace(_tag, message, args);
		}

		public void Error(string message, params object[] args)
		{
			Mvx.TaggedError(_tag, message, args);
		}
	}
}
