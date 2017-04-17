using System;
using System.Collections.Generic;
using SQLite.Net;
using System.Linq;
using SQLite.Net.Async;
using System.Threading.Tasks;
using System.Linq.Expressions;
using NGIS.Forms;

namespace MVXmapForms.Services
{
	public interface IRepositoryService<T> where T : class, new()
	{
		Task<List<T>> Get();
		Task<T> Get(int id);
		Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null);
		Task<T> Get(Expression<Func<T, bool>> predicate);
		AsyncTableQuery<T> AsQueryable();
		Task<int> Insert(T entity);
		Task<int> Update(T entity);
		Task<int> Delete(T entity);
	}

	public class RepositoryService<T> : IRepositoryService<T> where T : class, new()
	{
		private SQLiteAsyncConnection _db;

		public RepositoryService()
		{
			var param = new SQLiteConnectionString(GlobalConfiguration.Instance.PathToDB, false);
			_db = new SQLiteAsyncConnection(() => new SQLiteConnectionWithLock(GlobalConfiguration.Instance.Platform, param));
		}
		// alternative connection
		public RepositoryService(SQLiteAsyncConnection db)
		{
			this._db = db;
		}

		public AsyncTableQuery<T> AsQueryable() =>
			_db.Table<T>();

		public async Task<List<T>> Get() =>
			await _db.Table<T>().ToListAsync();

		public async Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
		{
			var query = _db.Table<T>();

			if (predicate != null)
				query = query.Where(predicate);

			if (orderBy != null)
				query = query.OrderBy<TValue>(orderBy);

			return await query.ToListAsync();
		}

		public async Task<T> Get(int id) =>
			 await _db.FindAsync<T>(id);

		public async Task<T> Get(Expression<Func<T, bool>> predicate) =>
			await _db.FindAsync<T>(predicate);

		public async Task<int> Insert(T entity) =>
			 await _db.InsertAsync(entity);

		public async Task<int> Update(T entity) =>
			 await _db.UpdateAsync(entity);

		public async Task<int> Delete(T entity) =>
			 await _db.DeleteAsync(entity);
	}
}
