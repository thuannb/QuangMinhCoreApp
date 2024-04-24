using KBStarCoreApp.Application.ViewModels.System;
using KBStarCoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KBStarCoreApp.Application.Interfaces
{
    public interface IRoleService
    {
        Task<bool> AddAsync(AnnouncementViewModel announcement, List<AnnouncementUserViewModel> announcementUsers, AppRoleViewModel userVm);

        Task<bool> AddAsync(AppRoleViewModel userVm);

        Task DeleteAsync(Guid id);

        Task<List<AppRoleViewModel>> GetAllAsync();

        PagedResult<AppRoleViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);

        Task<AppRoleViewModel> GetById(Guid id);


        Task UpdateAsync(AppRoleViewModel userVm);

        List<PermissionViewModel> GetListFunctionWithRole(string roleId);

        void SavePermission(List<PermissionViewModel> permissions, string roleId);

        Task<bool> CheckPermission(string functionId, string action, string[] roles);
    }
}
