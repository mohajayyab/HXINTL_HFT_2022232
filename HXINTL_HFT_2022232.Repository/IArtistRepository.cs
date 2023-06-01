using HXINTL_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXINTL_HFT_2022232.Repository
{
    public interface IArtistRepository
    {
        void Create(Artist ArtistEvent);
        void Delete(int Artistid);
        IQueryable<Artist> GetAll();
        Artist Read(int Artistid);
        void Update(Artist ArtistEvent);
    }
}
