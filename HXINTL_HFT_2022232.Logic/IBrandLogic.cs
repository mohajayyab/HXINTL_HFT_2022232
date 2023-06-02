using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXINTL_HFT_2022232.Models;

namespace HXINTL_HFT_2022232.Logic
{
     public interface IBrandLogic
    {
        void Create(Brand obj);
        Brand Read(int id);
        IQueryable<Brand> ReadAll();
        void Update(Brand obj);
        void Delete(int id);


        IEnumerable<Brand> GetBrandWithSanya();
        IEnumerable<Brand> GetBrandWhereGenderIsMale();
    }
}
