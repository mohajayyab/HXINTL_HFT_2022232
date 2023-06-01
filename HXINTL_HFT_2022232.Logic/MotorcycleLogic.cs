using HXINTL_HFT_2022232.Models;
using HXINTL_HFT_2022232.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HXINTL_HFT_2022232.Logic
{
    public class MotorcycleLogic : IMotorcycleLogic
    {
        IRepository<Motorcycle> MotorcycleRepo;

        //DP injection
        public MotorcycleLogic(IRepository<Motorcycle> MotorcycleRepo)
        {
            this.MotorcycleRepo = MotorcycleRepo;
        }

        public void Create(Motorcycle obj)
        {

            MotorcycleRepo.Create(obj);
        }

        public void Delete(int id)
        {
            MotorcycleRepo.Delete(id);
        }

        public Motorcycle Read(int id)
        {
      
            return MotorcycleRepo.Read(id);

        }

        public IQueryable<Motorcycle> ReadAll()
        {
            return MotorcycleRepo.ReadAll();
        }

        public void Update(Motorcycle obj)
        {
            MotorcycleRepo.Update(obj);
        }


    }
}
