using HXINTL_HFT_2022232.Models;
using HXINTL_HFT_2022232.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace HXINTL_HFT_2022232.Logic
{
    public class RentMotorcycleLogic : IRentMotorLogic
    {

        IRepository<Brand> BrandRepo;
        IRepository<Motorcycle> MotorcycleRepo;
        IRepository<RentMotorcycle> RentMotorcycleRepo;
        public RentMotorcycleLogic (IRepository<Brand> BrandRepo, IRepository<Motorcycle> MotorcycleRepo, IRepository<RentMotorcycle> RentMotorcycleRepo)
        {
            this.BrandRepo = BrandRepo;
            this.MotorcycleRepo = MotorcycleRepo;
            this.RentMotorcycleRepo = RentMotorcycleRepo;
        }



        public void Create(RentMotorcycle obj)
        {
            
            RentMotorcycleRepo.Create(obj);
        }

        public void Delete(int id)
        {
            RentMotorcycleRepo.Delete(id);
        }

        public RentMotorcycle Read(int id)
        {
        
            return RentMotorcycleRepo.Read(id);

        }

        public IQueryable<RentMotorcycle> ReadAll()
        {
            return RentMotorcycleRepo.ReadAll();
        }

        public void Update(RentMotorcycle obj)
        {
            RentMotorcycleRepo.Update(obj);
        }
        public IEnumerable<RentMotorcycle> GetRentMotorcycleReposAtBMWBrand()
        {


            var q = from RentMotorcycle in RentMotorcycleRepo.ReadAll()
                    join Motorcycle in MotorcycleRepo.ReadAll()
                    on RentMotorcycle.Motorcycle_id equals Motorcycle.Id
                    join Brands in BrandRepo.ReadAll()
                    on Motorcycle.Brand_id equals Brands.Id
                    where Brands.BrandName == "BMW"
                    select RentMotorcycle;

            return q.ToList();
        }
        public IEnumerable<RentMotorcycle> GetRentMotorcycleRepoWhereMotorPriceIsOver4()
        {
            var q = from RentMotorcycle in RentMotorcycleRepo.ReadAll()
                    join Motorcycle in MotorcycleRepo.ReadAll()
                    on RentMotorcycle.Motorcycle_id equals Motorcycle.Id
                    where Motorcycle.MotorcyclePrice > 4
                    select RentMotorcycle;
            return q;
        }

        public IEnumerable<RentMotorcycle> GetRentMotorcycleReposWhereMotorModelNameIsBMWMotorcycle1()
        {
            var q = from RentMotorcycle in RentMotorcycleRepo.ReadAll()
                    join Motorcycle in MotorcycleRepo.ReadAll()
                    on RentMotorcycle.Motorcycle_id equals Motorcycle.Id
                    where Motorcycle.MotorcycleName == "BMW Motorcycle1"
                    select RentMotorcycle;
            return q;
        }

        public IEnumerable<RentMotorcycle> GetRentMotorcycleReposWhereCarModelNameIsBMWMotorcycle12()
        {
            var q = from RentMotorcycle in RentMotorcycleRepo.ReadAll()
                    join Motorcycle in MotorcycleRepo.ReadAll()
                    on RentMotorcycle.Motorcycle_id equals Motorcycle.Id
                    where Motorcycle.MotorcycleName == "BMW Motorcycle1"
                    select RentMotorcycle;
            return q;
        }
    }
}