﻿using KBStarCoreApp.Application.Interfaces;
using KBStarCoreApp.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace KBStarCoreApp.Areas.Admin.Controllers
{
    public class AnnouncementController : BaseController
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }
        [HttpGet]
        public IActionResult GetAllPaging(int page, int pageSize)
        {
            var model = _announcementService.GetAllUnReadPaging(User.GetUserId(), page, pageSize);
            return new OkObjectResult(model);
        }

        [HttpPost]
        public IActionResult MarkAsRead(string id)
        {
            var result = _announcementService.MarkAsRead(User.GetUserId(), id);
            return new OkObjectResult(result);
        }
    }
}
