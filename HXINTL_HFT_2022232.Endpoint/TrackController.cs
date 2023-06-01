using HXINTL_HFT_2022232.Endpoint;
using HXINTL_HFT_2022232.Logic;
using HXINTL_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace HXINTL_HFT_2022232.Endpoint
{
    public class TrackController : Controller
    {
        IBrandLogic t1;
        public TrackController(IBrandLogic t1)
        {
            this.t1 = t1;

        }
        [HttpGet]
        public IEnumerable<Track> Get()
        {
            return t1.GetTracks();
        }

        // GET /brand/5
        [HttpGet("{id}")]
        public Track Get(int TrackId)
        {
            return t1.GetTrack(TrackId);
        }

        // POST /brand
        [HttpPost]
        public void Post([FromBody] Track value)
        {
            t1.CreatTrack(value.TrackId, value.NamePlace, value.Length);
        }

        // PUT /brand
        [HttpPut]
        public void Put([FromBody] Track value)
        {
            t1.UpdateTrack(value);
        }

        // DELETE /brand/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            t1.DeleteTrack(id);
        }
    }
}
