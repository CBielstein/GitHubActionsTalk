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

        [Fact]
        public async Task TestGet()
        {
            var response = await client.GetAsync("/hello");
            var message = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("Hello, World", message);
        }
    }
}
