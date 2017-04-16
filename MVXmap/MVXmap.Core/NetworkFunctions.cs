using System;
using System.Net.NetworkInformation;

namespace MVXMap.Core
{
	public interface INetworkFunctions
	{
		bool IsNetworkAvailable();
	}

	public class NetworkFunctions : INetworkFunctions
	{
		public string HostName = "www.google.com";

		public bool IsNetworkAvailable()
		{
			return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

			// Ping's the local machine.
			// Ping's the local machine.
			// Ping pingSender = new Ping();
			// IPAddress address = IPAddress.Loopback;
			// PingReply reply = pingSender.Send(address);

			// if (reply.Status == IPStatus.Success)
			//	return true;
			//return false;
		}
	}
}