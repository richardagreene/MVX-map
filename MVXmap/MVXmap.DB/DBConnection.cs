using System;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;

namespace MVXmap.DB
{
	public static class DBConnection
	{
		public static string PathToDB { get; set; }
		public static ISQLitePlatform Platform { get; set; } 
		public static SQLiteAsyncConnection Connection
		{
			get
			{
				var param = new SQLiteConnectionString(PathToDB, false);
				var connection = new SQLiteAsyncConnection(() => new SQLiteConnectionWithLock(Platform, param));
				return connection;
			}
		}
	}
}

