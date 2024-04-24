using KBStarCoreApp.Application.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace KBStarCoreApp.Application.Interfaces
{
    public interface ILINhVatTuService
    {
        List<LINhVatTuViewModel> GetAll();

        List<LINhVatTuViewModel> GetAll(string keyword);

        List<LINhVatTuViewModel> GetAllByParentId(string parentId);

        LINhVatTuViewModel GetById(string id);

        List<LINhVatTuViewModel> GetHomeCategories(int top);
    }
}
