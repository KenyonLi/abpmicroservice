using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace LKN.AuthMicroService.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}
