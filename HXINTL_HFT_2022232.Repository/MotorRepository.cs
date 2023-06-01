using HXINTL_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HXINTL_HFT_2022232.Repository
{
    public class MotorRepository : Repository<Motorcycle>
    {
        public MotorRepository(MotorsDBContext hpdb) : base(hpdb)
        {
        }
        public override Motorcycle Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }
        public override void Update(Motorcycle obj)
        {
            var oldMotorcycle = Read(obj.Id);
            oldMotorcycle.Id = obj.Id;
            oldMotorcycle.MotorcycleName = obj.MotorcycleName;
            oldMotorcycle.MotorcycleType = obj.MotorcycleType;
            oldMotorcycle.MotorcyclePrice = obj.MotorcyclePrice;
            oldMotorcycle.MotorcycleReleaseYear = obj.MotorcycleReleaseYear;
            oldMotorcycle.MotorcycleColor = obj.MotorcycleColor;
            oldMotorcycle.MotorcycleSeatNumber = obj.MotorcycleSeatNumber;
            oldMotorcycle.IsLeftWheel = obj.IsLeftWheel;
            oldMotorcycle.FuelType = obj.FuelType;
            oldMotorcycle.IsElectricMotorcycle = obj.IsElectricMotorcycle;
            oldMotorcycle.Brand_id = obj.Brand_id;
            db.SaveChanges();
        }
        public override void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }
    }
}
