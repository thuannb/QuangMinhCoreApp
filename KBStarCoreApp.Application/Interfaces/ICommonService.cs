﻿using KBStarCoreApp.Application.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace KBStarCoreApp.Application.Interfaces
{
	public interface ICommonService
	{
		FooterViewModel GetFooter();
		List<SlideViewModel> GetSlides(string groupAlias);
		SystemConfigViewModel GetSystemConfig(string code);
	}
}
