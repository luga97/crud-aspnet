using BrandsCrud.Data;
using BrandsCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BrandsCrud.Repositorio
{
    public class VehiclesBrandsRepository : IBrandsRepository
    {
        private readonly CrudContext _context;

        public VehiclesBrandsRepository(CrudContext context)
        {
            this._context = context;
        }

        public BrandModel FindById(int id)
        {
            return _context.Brands.FirstOrDefault(x => x.Id == id);
        }

        public List<BrandModel> FindAll()
        {
            return _context.Brands.ToList();
        }

        public BrandModel Add(BrandModel brand)
        {
            _context.Brands.Add(brand);
            _context.SaveChanges();
            return brand;
        }

        public BrandModel Update(BrandModel brand)
        {
            BrandModel brandDB = FindById(brand.Id);

            if (brandDB == null) throw new Exception("Houve um erro na atualização da marca!");

            brandDB.Name = brand.Name;
            brandDB.National = brand.National;
            brandDB.Active = brand.Active;

            _context.Brands.Update(brandDB);
            _context.SaveChanges();

            return brandDB;
        }

        public bool Delete(int id)
        {
            BrandModel brandDB = FindById(id);

            if (brandDB == null) throw new Exception("Houve um erro na deleção da marca!");

            _context.Brands.Remove(brandDB);
            _context.SaveChanges();

            return true;
        }
    }
}
