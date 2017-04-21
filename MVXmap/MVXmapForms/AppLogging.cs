using System;
using MvvmCross.Platform;

namespace MVXmapForms
{
	public static class AppLogging
	{
		static readonly string _tag = "MVXmap";

		public static void Error(string message, params object[] args)
		{
			Mvx.TaggedError(_tag, message, args);
		}

		public static void Warning(string message, params object[] args)
		{
			Mvx.TaggedWarning(_tag, message, args);
		}

		public static void Debug(string message, params object[] args)
		{
			Mvx.TaggedTrace(_tag, message, args);
		}
	}
}
