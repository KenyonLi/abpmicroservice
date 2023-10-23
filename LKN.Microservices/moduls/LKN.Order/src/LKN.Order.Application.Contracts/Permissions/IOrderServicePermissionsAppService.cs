using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LKN.Order.Permissions
{
    /// <summary>
    /// 授权接口
    /// </summary>
    public interface IOrderServicePermissionsAppService
    {
        public Task AddRolePermissionAsync(string roleName, string permission);

        public Task AddUserPermissionAsync(Guid userId, string permission);

        public Task AddClientPermissionAsync(string ClientName, string permission);
    }
}
