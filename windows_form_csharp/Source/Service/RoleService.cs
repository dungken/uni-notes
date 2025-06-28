using Source.DataAcess;
using Source.Dtos.Reponse;
using Source.Dtos.Role;
using Source.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Service
{
    public class RoleService
    {
        private readonly ApiClient _apiClient;
        public RoleService()
        {
            _apiClient = new ApiClient(Utils.Config.BaseUrl);
        }

        // Create a new role
        public async Task<BaseResponse<Role>> CreateRoleAsync(CreateRoleDto roleDto)
        {
            return await _apiClient.PostAsync<BaseResponse<Role>>("Role/CreateOrUpdate", roleDto);
        }

        // Get all roles
        public async Task<BaseResponse<IEnumerable<RoleDto>>> GetAllRoles()
        {
            return await _apiClient.GetAsync<BaseResponse<IEnumerable<RoleDto>>>("Role/GetAll");

        }

        // Get role by id
        public async Task<BaseResponse<RoleDto>> GetRoleByIdAsync(Guid roleId)
        {
            return await _apiClient.GetAsync<BaseResponse<RoleDto>>($"Role/{roleId}");
        }

        // Assignment Permission to Role
        public async Task<BaseResponse<object>> AssignPermissionToRole(AssignPermissionsRequest request)
        {
            return await _apiClient.PostAsync<BaseResponse<object>>($"Role/AssignPermission", request);
        }

        // Delete role
        public async Task<bool> DeleteRole(Guid roleId)
        {
            return await _apiClient.DeleteAsync($"Role/Delete/{roleId}");
        }
    }
}
