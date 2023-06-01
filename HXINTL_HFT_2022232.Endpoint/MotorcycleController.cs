using HXINTL_HFT_2022232.Logic;
using HXINTL_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace I0ZMN2_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MotorcycleController : ControllerBase
    {
        IMotorcycleLogic motorlogic;

        public MotorcycleController(IMotorcycleLogic motorlogic)
        {
            this.motorlogic = motorlogic;
        }

        [HttpGet]
        public IEnumerable<Motorcycle> Get()
        {
            return motorlogic.ReadAll();
        }

        [HttpGet("{id}")]
        public Motorcycle Get(int id)
        {
            return motorlogic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Motorcycle value)
        {
            motorlogic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Motorcycle value)
        {
            motorlogic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var CarToDelete = this.motorlogic.Read(id);
            motorlogic.Delete(id);

        }
    }
}
