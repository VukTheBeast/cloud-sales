using Crayon.TechExercise.CloudSales.Application.CloudServiceProvider;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace Crayon.TechExercise.CloudSales.Infrastructure.Clients;

public class CcpApiClient : ICcpClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<CcpApiClient> _logger;
    private readonly List<CcpSoftwareResult> _mockSoftwareList =
    [
        new (1, "Software A", "Microsoft"),
        new (2, "Software B", "Aws"),
        new (3, "Software C", "Adobe"),
        new (4, "Software D", "ProviderOne"),
        new (5, "Software E", "Adobe"),
        new (6, "Software F", "SAP"),
        new (7, "Software G", "Microsoft"),
        new (8, "Software H", "Aws"),
        new (9, "Software I", "SAP"),
        new (10, "Software J", "Adobe")
    ];

    public CcpApiClient(HttpClient httpClient, ILogger<CcpApiClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<IEnumerable<CcpSoftwareResult>> GetSoftwareListAsync()
    {
        // Call to external api using http client.
        //try
        //{
        //    var response = await _httpClient.GetAsync("/software");
        //    response.EnsureSuccessStatusCode();
        //    return await response.Content.ReadFromJsonAsync<IEnumerable<CcpSoftwareResult>>();
        //}
        //catch (HttpRequestException ex)
        //{
        //    _logger.LogError("Error fetching software list from ccp: {message}", ex.Message);
        //    throw;
        //}

        await Task.Delay(500);

        return _mockSoftwareList;
    }

}
