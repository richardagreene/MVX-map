using System.Threading.Tasks;
using MVXMap.Core.Model;
using NGIS.Forms;
using SQLite.Net;
using SQLite.Net.Async;

namespace MVXmapForms.Services
{

	public interface IDataService
	{
		Task InitAsync();
	}

	/// <summary>
	/// Service which will initialise the database as needed
	/// </summary>
	public class DataService : IDataService
	{
		private readonly SQLiteAsyncConnection _connection;

		public DataService()
		{
			// Get the db connection
			var param = new SQLiteConnectionString(GlobalConfiguration.Instance.PathToDB, false);
			_connection = new SQLiteAsyncConnection(() => new SQLiteConnectionWithLock(GlobalConfiguration.Instance.Platform, param));
		}

		/// <summary>
		/// Init the database with all tables required.
		/// </summary>
		public async Task InitAsync()
		{
			// Define all tables we need
			System.Type[] tables = new System.Type[] {
				typeof(Suburb)
			};
			// execute the creation
			await _connection.CreateTablesAsync(tables);
		}
	}
}
