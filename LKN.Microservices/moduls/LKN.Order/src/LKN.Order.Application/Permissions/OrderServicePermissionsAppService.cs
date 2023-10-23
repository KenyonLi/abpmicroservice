using LKN.Order.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.PermissionManagement;

namespace LKN.Order.Permissions
{
    public class OrderServicePermissionsAppService : OrderAppService, IOrderServicePermissionsAppService
    {
        private readonly IPermissionManager _permissionManager;

        public OrderServicePermissionsAppService(IPermissionManager permissionManager)
        {
            _permissionManager = permissionManager;
        }


        public async Task AddRolePermissionAsync(string roleName, string permission)
        {
            await _permissionManager.SetAsync(permission, RolePermissionValueProvider.ProviderName, roleName, true);
        }

        public async Task AddUserPermissionAsync(Guid userId, string permission)
        {
            await _permissionManager.SetAsync(permission, UserPermissionValueProvider.ProviderName, userId.ToString(), true);
        }
        public async Task AddClientPermissionAsync(string ClientName, string permission)
        {
            await _permissionManager.SetAsync(permission, ClientPermissionValueProvider.ProviderName, ClientName, true);
        }
    }
}
