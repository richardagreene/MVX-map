using System;
using System.Net.Http;
using System.Threading.Tasks;
using ModernHttpClient;

namespace MVXmapForms.Services
{
	public interface INetworkAPIService
	{
		Task<string> GetData();
	}

	public class NetworkAPIService : BaseClass, INetworkAPIService
	{
		public NetworkAPIService()
		{
		}

		/// <summary>
		/// Gets from any data.
		/// </summary>
		/// <returns>The data.</returns>
		public async Task<string> GetData()
		{
			var httpClient = new HttpClient(new NativeMessageHandler());
			httpClient.Timeout = TimeSpan.FromSeconds(5);
			var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts/1");

			response.EnsureSuccessStatusCode();
			string content = await response.Content.ReadAsStringAsync();
			_log.Debug("API results=>{0}", content);
			return content;
		}
	}
}

