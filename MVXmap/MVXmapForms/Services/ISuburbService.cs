using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVXMap.Core.Model;

namespace MVXmapForms.Services
{
	public interface ISuburbService
	{
		Task<List<Suburb>> Get();
		Task<int> Insert(Suburb suburb);
	}

	/// <summary>
	/// Needed as the services can't refect on generic parameters
	/// </summary>
	public class SuburbService : BaseClass, ISuburbService
	{
		private readonly IRepositoryService<Suburb> _repo = null;
		public SuburbService()
		{
			_repo = new RepositoryService<Suburb>();
		}

		public async Task<List<Suburb>> Get()
		{
			try
			{
				return await _repo.Get();
			}
			catch (Exception ex)
			{
				_log.Error("SQL Error: {0}", ex.Message);
				return new List<Suburb>();
			}
		}
		public async Task<int> Insert(Suburb suburb)
		{
			try
			{
				return await _repo.Insert(suburb);
			}
			catch (Exception ex)
			{
				_log.Error("SQL Error: {0}", ex.Message);
				return 0;
			}
		}
	}
}
