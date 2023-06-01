using HXINTL_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXINTL_HFT_2022232.Repository
{
    public class RentMotorcycleRepository : Repository<RentMotorcycle>
    {
        public RentMotorcycleRepository(MotorsDBContext hpdb) : base(hpdb)
        {
        }

        public override RentMotorcycle Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }
        public override void Update(RentMotorcycle obj)
        {
            var oldRentMotorcycle = Read(obj.Id);
            oldRentMotorcycle.Id = obj.Id;
            oldRentMotorcycle.BuyerName = obj.BuyerName;
            oldRentMotorcycle.BuyDate = obj.BuyDate;
            oldRentMotorcycle.BuyerGender = obj.BuyerGender;
            oldRentMotorcycle.IsFirstMotorcycle = obj.IsFirstMotorcycle;
            oldRentMotorcycle.Motorcycle_id = obj.Motorcycle_id;
            db.SaveChanges();
        }
        public override void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }
    }
}
