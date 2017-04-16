using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using MVXmap.DB;
using MVXmapForms.Services;

namespace MVXmapForms.ViewModels
{
	public class MappingViewModel : MvxViewModel
	{
		ISuburbService _repo;
		public MappingViewModel(ISuburbService repo)
		{
			_repo = repo;
//			var x = this.Suburbs.Count;
		}

		List<Suburb> _suburbs = new List<Suburb>();
		public List<Suburb> Suburbs
		{
			get { return _repo.GetSuburbs().GetAwaiter().GetResult(); }
		}
	}
}
