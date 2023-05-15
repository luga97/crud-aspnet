using BrandsCrud.Models;
using System.Collections.Generic;

namespace BrandsCrud.Repositorio
{
    public interface IBrandsRepository
    {
        List<BrandModel> FindAll();
        BrandModel FindById(int id);
        BrandModel Add(BrandModel brand);
        BrandModel Update(BrandModel brand);
        bool Delete (int id);
    }
}
