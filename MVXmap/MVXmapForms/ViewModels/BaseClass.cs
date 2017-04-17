using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace MVXmapForms
{
	public abstract class BaseClass : MvxViewModel
	{
		protected IAppLoggingService _log { get { return Mvx.Resolve<IAppLoggingService>(); } }

		public BaseClass()
		{
		}
	}
}
