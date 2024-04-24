using KBStarCoreApp.Application.ViewModels.System;
using KBStarCoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace KBStarCoreApp.Application.Interfaces
{
    public interface IAnnouncementService
    {
        PagedResult<AnnouncementViewModel> GetAllUnReadPaging(string userId, int pageIndex, int pageSize);

        bool MarkAsRead(string userId, string id);
    }
}
