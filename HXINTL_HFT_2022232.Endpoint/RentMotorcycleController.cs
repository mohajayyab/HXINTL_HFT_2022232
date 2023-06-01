using HXINTL_HFT_2022232.Logic;
using HXINTL_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HXINTL_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RentMotorcycleController : ControllerBase
    {
        IRentMotorLogic rentmotorlogic;

        public RentMotorcycleController(IRentMotorLogic rentmotorlogic)
        {
            this.rentmotorlogic = rentmotorlogic;
        }

      
        [HttpGet]
        public IEnumerable<RentMotorcycle> Get()
        {
            return rentmotorlogic.ReadAll();
        }

        [HttpGet("{id}")]
        public RentMotorcycle Get(int id)
        {
            return rentmotorlogic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] RentMotorcycle value)
        {
            rentmotorlogic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] RentMotorcycle value)
        {
            rentmotorlogic.Update(value);
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var RentCarToDelete = this.rentmotorlogic.Read(id);
            rentmotorlogic.Delete(id);
        }
    }
}
