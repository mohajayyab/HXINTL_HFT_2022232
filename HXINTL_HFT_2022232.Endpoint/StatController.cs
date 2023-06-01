using HXINTL_HFT_2022232.Logic;
using HXINTL_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HXINTL_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IRentMotorLogic rentmotorlogic;
        IBrandLogic brandlogic;

        public StatController(IRentMotorLogic rentmotorlogic, IBrandLogic brandlogic)
        {
            this.rentmotorlogic = rentmotorlogic;
            this.brandlogic = brandlogic;
        }

        [HttpGet]
        public IEnumerable<RentMotorcycle> GetRentMotorcycleReposAtBMWBrand()
        {
            return rentmotorlogic.GetRentMotorcycleReposAtBMWBrand();
        }
        [HttpGet]
        public IEnumerable<RentMotorcycle> GetRentMotorcycleRepoWhereMotorPriceIsOver4() 
        {
            return rentmotorlogic.GetRentMotorcycleRepoWhereMotorPriceIsOver4();
        }
        [HttpGet]
        public IEnumerable<RentMotorcycle> GetRentMotorcycleReposWhereMotorModelNameIsBMWMotorcycle1()
        {
            return rentmotorlogic.GetRentMotorcycleReposWhereMotorModelNameIsBMWMotorcycle1();
        }

        [HttpGet]
        public IEnumerable<Brand> GetBrandWithSanya()
        {
            return brandlogic.GetBrandWithSanya();
        }
        [HttpGet]
        public IEnumerable<Brand> GetBrandWhereGenderIsMale()
        {
            return brandlogic.GetBrandWhereGenderIsMale();
        }
    }
}
