using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace LKN.AuthMicroService.ApiResources
{
    public class UpdateClientDto : EntityDto<Guid>
    {
        public string ClientName { get; set; }
        public string Secret { get; set; }
        public string RedirectUri { get; set; }
        public string PostLogoutRedirectUri { get; set; }
        public IEnumerable<string> Scopes { set; get; }
        public IEnumerable<string> GrantTypes { set; get; }
    }
}
