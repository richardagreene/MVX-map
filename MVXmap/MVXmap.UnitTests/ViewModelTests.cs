using NUnit.Framework;
using System;
using MVXmapForms.ViewModels;
using Moq;
using MVXmapForms.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVXMap.Core.Model;
using MvvmCross.Test.Core;
using MvvmCross.Core;

namespace MVXmap.UnitTests
{
	[TestFixture()]
	public class ViewModelTests : MvxIoCSupportingTest
	{
		[Test()]
		public void MainTabbed_Should_ReturnTabPages()
		{
			// Arrange
			base.Setup();
			// -- Suburb
			var mockSuburb = new Mock<ISuburbService>();
			mockSuburb.Setup( g=>g.Get()).Returns(Task.FromResult(new List<Suburb>()));
			Ioc.RegisterSingleton<ISuburbService>(mockSuburb.Object);
			// -- Network
			var mockNetwork = new Mock<INetworkAPIService>();
			Ioc.RegisterSingleton<INetworkAPIService>(mockNetwork.Object);

			// Act
			NetworkViewModel view = new NetworkViewModel(mockNetwork.Object);

			// Assert
			Assert.True(String.IsNullOrEmpty(view.APIResult));
		}
	}
}
