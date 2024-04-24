using KBStarCoreApp.Data.Entities;
using KBStarCoreApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KBStarCoreApp.Data.IRepositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory_, int>
    {
        List<ProductCategory_> GetByAlias(string alias);
    }
}
