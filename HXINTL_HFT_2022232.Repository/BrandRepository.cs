using HXINTL_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXINTL_HFT_2022232.Repository
{
    public class BrandRepository : Repository<Brand>
    {
        public BrandRepository(MotorsDBContext db) : base(db)
        {
        }
        public override Brand Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }
        public override void Update(Brand obj)
        {
            var oldBrand = Read(obj.Id);
            oldBrand.Id = obj.Id;
            oldBrand.BrandName = obj.BrandName;
            oldBrand.BrandCountry = obj.BrandCountry;
            oldBrand.BrandYear = obj.BrandYear;

            db.SaveChanges();
        }
        public override void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }
    }
}
