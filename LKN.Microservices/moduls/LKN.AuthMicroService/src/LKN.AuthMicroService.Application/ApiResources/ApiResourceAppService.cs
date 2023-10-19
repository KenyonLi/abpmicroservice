using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.IdentityServer.ApiResources;
using Volo.Abp.Modularity;

namespace LKN.AuthMicroService.ApiResources
{
    [Dependency(ServiceLifetime.Singleton)]
    public class ApiResourceAppService: AuthMicroServiceAppService,IApiResourceAppService
    {
        public IApiResourceRepository _apiResourceRepository;
        public ApiResourceAppService(IApiResourceRepository apiResourceRepository)
        {
            this._apiResourceRepository = apiResourceRepository;
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }

    }
}
