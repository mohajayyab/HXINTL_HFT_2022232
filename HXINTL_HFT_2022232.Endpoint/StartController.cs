using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HXINTL_HFT_2022232.Models;
using HXINTL_HFT_2022232.Logic;

namespace HXINTL_HFT_2022232.Endpoint
{
    public class StatController : Controller
    {

        readonly IAlbumLogic a1;
        public StatController(IAlbumLogic a1)
        {
            this.a1 = a1;
        }

        // GET: stat/avgprice
        [HttpGet]
        public double AVGPrice()
        {
            return a1.AVGPrice();
        }

        // GET: stat/avgpricebybrands
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGPriceByBrands()
        {
            return a1.AVGPriceByAlbums();
        }
    }
}
