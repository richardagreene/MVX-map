using System;
using SQLite.Net.Attributes;

namespace MVXmap.DB
{
	public class Suburb
	{
		public Suburb()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		[MaxLength(256)]
		public string Name { get; set; }
		public double Long { get; set; }
		public double LAT { get; set; }
	}
}
