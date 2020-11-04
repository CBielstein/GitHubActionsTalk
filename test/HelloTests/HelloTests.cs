using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace HelloTests
{
    public class HelloTests
    {
        private readonly TestServer server;
        private readonly HttpClient client;

        public HelloTests()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Hello.Startup>();
            server = new TestServer(builder);
            client = server.CreateClient();
        }

        [Theory]
        [InlineData("Cameron")]
        [InlineData("Fraveshi")]
        public async Task TestNameQueryStringAsync(string name)
        {
            var response = await client.GetAsync($"/hello?name={name}");
            var message = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal($"Hello, {name}", message);
        }
    }
}
