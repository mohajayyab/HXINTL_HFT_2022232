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
    public class BrandLogic : IBrandLogic
    {
        
        

            IRepository<Brand> brandRepo;
            IRepository<Motorcycle> motorcycleRepo;
            IRepository<RentMotorcycle> rentmotorcycleRepo;

            public BrandLogic(IRepository<Brand> brandRepo, IRepository<Motorcycle> carRepo, IRepository<RentMotorcycle> rentcarRepo)
            {
                this.brandRepo = brandRepo;
                this.motorcycleRepo = carRepo;
                this.rentmotorcycleRepo= rentcarRepo;
            }

            public void Create(Brand obj)
            {
               
                brandRepo.Create(obj);
            }

            public void Delete(int id)
            {
                brandRepo.Delete(id);
            }

            public Brand Read(int id)
            {
                
                return brandRepo.Read(id);
            }

            public IQueryable<Brand> ReadAll()
            {
                return brandRepo.ReadAll();
            }

            public void Update(Brand obj)
            {
                brandRepo.Update(obj);
            }

            public IEnumerable<Brand> GetBrandWithSanya()
            {
                var q = from RentMotors in rentmotorcycleRepo.ReadAll()
                        join Motors in motorcycleRepo.ReadAll()
                        on RentMotors.Motorcycle_id equals Motors.Id
                        join Brands in brandRepo.ReadAll()
                        on Motors.Brand_id equals Brands.Id
                        where RentMotors.BuyerName == "Sanya"
                        select Brands;
                return q;
            }

            public IEnumerable<Brand> GetBrandWhereGenderIsMale()
            {
                var q = from RentMotors in rentmotorcycleRepo.ReadAll()
                        join Motors in motorcycleRepo.ReadAll()
                        on RentMotors.Motorcycle_id equals Motors.Id
                        join Brands in brandRepo.ReadAll()
                        on Motors.Brand_id equals Brands.Id
                        where RentMotors.BuyerGender == "male"
                        select Brands;
                return q;
            }
        
    }
}