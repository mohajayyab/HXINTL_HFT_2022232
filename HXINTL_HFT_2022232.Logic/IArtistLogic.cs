using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXINTL_HFT_2022232.Models;

namespace HXINTL_HFT_2022232.Logic
{
    public interface IArtistLogic
    {
        List<Artist> GetArtists();
        Artist GetArtist(int ArtistId);
        void CreatArtist(string name, int age, int albumId, int artistId);
        void UpdateArtist(Artist artist);
        void DeleteArtist(int ArtistId);
    }
}
