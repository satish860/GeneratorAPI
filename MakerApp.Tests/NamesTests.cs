using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Linq;
using Newtonsoft.Json;

namespace MakerApp.Tests
{
    public class GeneratorTests
        : IClassFixture<WebApplicationFactory<Startup>>
    {

        private HttpClient httpClient;
        public GeneratorTests(WebApplicationFactory<Startup> webApplicationFactory)
        {
            httpClient = webApplicationFactory.CreateDefaultClient();

        }

        [Fact]
        public async Task ShouldBeAbleToGetSucessFromController()
        {
            var response = await this.httpClient.GetAsync("/Names");
            response.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]
        public async Task ShouldBeAbleToGetListOfTenFakeNamesFromController()
        {
            var response = await this.httpClient.GetAsync("/Names");
            var responsedata = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<IEnumerable<string>>(responsedata);
            data.Count().Should().Be(10);
        }
    }
}
