using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HXINTL_HFT_2022232.Logic;
using HXINTL_HFT_2022232.Models;

namespace HXINTL_HFT_2022232.Endpoint
{
    public class AlbumController : Controller
    {
        readonly IAlbumLogic a1;
        public AlbumController(IAlbumLogic a1)
        {
            this.a1 = a1;

        }
        [HttpGet]
        public IEnumerable<Album> Get()
        {
            return a1.GetAlbums();
        }

        // GET /brand/5
        [HttpGet("{id}")]
        public Album Get(int AlbumId)
        {
            return a1.GetAlbum(AlbumId);
        }

        // POST /brand
        [HttpPost]
        public void Post([FromBody] Album value)
        {
            a1.CreateAlbum(value.AlbumID, value.Title);
        }

        // PUT /brand
        [HttpPut]
        public void Put([FromBody] Album value)
        {
            a1.UpdateAlbum(value);
        }

        // DELETE /brand/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            a1.DeleteAlbum(id);
        }
    }
}
