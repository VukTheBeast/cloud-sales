using Crayon.TechExercise.CloudSales.Application.CloudServiceProvider;
using Crayon.TechExercise.CloudSales.Infrastructure.Clients;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using RichardSzalay.MockHttp;
using Shouldly;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace Crayon.TechExercise.CloudSales.Infrastructure.Tests;

public class CcpApiClientTests
{
    private MockHttpMessageHandler _mockHttp;
    private ILogger<CcpApiClient> _logger;
    private CcpApiClient _client;

    [SetUp]
    public void Setup()
    {
        _mockHttp = new MockHttpMessageHandler();
        var httpClient = _mockHttp.ToHttpClient();
        httpClient.BaseAddress = new Uri("https://fake-ccp.com");

        _logger = A.Fake<ILogger<CcpApiClient>>();
        _client = new CcpApiClient(httpClient, _logger);
    }

    // this test should cover implementation of CcpApiClient.GetSoftwareListAsync
    // -> uncomment implementation, then you can run test

    //[Test]
    //public async Task GetSoftwareListAsync_Should_Return_Data_When_Api_Succeeds()
    //{
    //    // Arrange
    //    var expected = new List<CcpSoftwareResult>
    //    {
    //        new(1, "Software Z", "VendorX"),
    //        new(2, "Software Y", "VendorY")
    //    };

    //    _mockHttp.When(HttpMethod.Get, "https://fake-ccp.com/software")
    //             .Respond("application/json", JsonContent.Create(expected).ReadAsStringAsync().Result);

    //    // Act
    //    var result = await _client.GetSoftwareListAsync();

    //    // Assert
    //    result.ShouldNotBeNull();
    //    result.Count().ShouldBe(2);
    //    result.First().Name.ShouldBe("Software Z");
    //}

    //[Test]
    //public void GetSoftwareListAsync_Should_Log_And_Throw_On_Failure()
    //{
    //    // Arrange
    //    _mockHttp.When(HttpMethod.Get, "https://fake-ccp.com/software")
    //             .Respond(HttpStatusCode.InternalServerError);

    //    // Act & Assert
    //    var ex = Should.ThrowAsync<HttpRequestException>(() => _client.GetSoftwareListAsync());
    //}
}
