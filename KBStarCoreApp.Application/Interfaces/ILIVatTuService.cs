using KBStarCoreApp.Application.ViewModels.Common;
using KBStarCoreApp.Application.ViewModels.Product;
using KBStarCoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace KBStarCoreApp.Application.Interfaces
{
    public interface ILIVatTuService : IDisposable
    {
        List<LIVatTuViewModel> GetAll();

        PagedResult<LIVatTuViewModel> GetAllPaging(string categoryId, string keyword, int page, int pageSize);

        //ProductViewModel Add(LIVatTuViewModel product);

        //void Update(LIVatTuViewModel product);

        //void Delete(int id);

        LIVatTuViewModel GetById(string id);

        //void ImportExcel(string filePath, int categoryId);

        //void Save();

        //void AddQuantity(int productId, List<ProductQuantityViewModel> quantities);

        //List<ProductQuantityViewModel> GetQuantities(int productId);

        //void AddImages(int productId, string[] images);

        //List<ProductImageViewModel> GetImages(int productId);

        //void AddWholePrice(int productId, List<WholePriceViewModel> wholePrices);

        //List<WholePriceViewModel> GetWholePrices(int productId);

        //List<ProductViewModel> GetLastest(int top);

        //List<ProductViewModel> GetHotProduct(int top);

        List<LIVatTuViewModel> GetRelatedProducts(string ma_Vt, int top);

        //List<ProductViewModel> GetUpsellProducts(int top);

        //List<TagViewModel> GetProductTags(int productId);
    }
}
