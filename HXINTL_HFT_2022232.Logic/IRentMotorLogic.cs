
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXINTL_HFT_2022232.Models;

namespace HXINTL_HFT_2022232.Logic
{
    public interface IRentMotorLogic
    {
        
        void Create(RentMotorcycle obj);
        RentMotorcycle Read(int id);
        IQueryable<RentMotorcycle> ReadAll();
        void Update(RentMotorcycle obj);
        void Delete(int id);

        
        IEnumerable<RentMotorcycle> GetRentMotorcycleAtBMWBrand();
        IEnumerable<RentMotorcycle> GetRentMotorcycleWhereMotorPriceIsOver4();
        IEnumerable<RentMotorcycle> GetRentMotorcycleWhereMotorModelNameIsBMWMotorcycle1();
        IEnumerable<RentMotorcycle> GetRentMotorcycleWhereCarModelNameIsBMWMotorcycle2();


    }
}
