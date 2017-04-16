using System;
using SQLite.Net.Interop;

namespace NGIS.Forms
{
	public class GlobalConfiguration
	{
		private GlobalConfiguration()
		{
		}

		private static GlobalConfiguration _globalConfiguration;
		private static object syncRoot = new Object();

		public static GlobalConfiguration Instance
		{
			get
			{
				lock (syncRoot)
					if (_globalConfiguration == null)
						_globalConfiguration = new GlobalConfiguration();
				return _globalConfiguration;
			}
		}

		public string MapsApiKey { get { return "AIzaSyBFfxyRlVgqGgg0Iabe42mp6Uz2nt0Wji8"; } }
		public string PathToDB { get; set; }
		public ISQLitePlatform Platform { get; set; }
	}
}