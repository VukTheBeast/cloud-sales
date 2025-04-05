namespace Crayon.TechExercise.CloudSales.Application.CloudServiceProvider;

public interface ICcpClient
{
    Task<IEnumerable<CcpSoftwareResult>> GetSoftwareListAsync();
}
