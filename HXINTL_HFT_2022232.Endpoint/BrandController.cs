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
    public class BrandController : ControllerBase
    {
        IBrandLogic logic;

        public BrandController(IBrandLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<BrandController>
        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Brand value)
        {
            logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Brand value)
        {
            logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var BrandToDelete = this.logic.Read(id);
            logic.Delete(id);
        }
    }
}
