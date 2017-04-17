using System;
using MvvmCross.Platform;

namespace MVXmapForms.Services
{
	public abstract class BaseClass
	{
		protected IAppLoggingService _log { get { return Mvx.Resolve<IAppLoggingService>(); } }

		public BaseClass()
		{
		}
	}
}
