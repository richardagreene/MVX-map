using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVXmap.DB;
using NGIS.Forms;

namespace MVXmapForms.Services
{
	public interface ISuburbService
	{
		Task<List<Suburb>> GetSuburbs();
	}

	public class SuburbService : ISuburbService
	{
		public async Task<List<Suburb>> GetSuburbs()
		{
			IRepository<Suburb> stockRepo = new Repository<Suburb>();
			return await stockRepo.Get();
		} 
	}	
}
