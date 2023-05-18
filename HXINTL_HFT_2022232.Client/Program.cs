using ConsoleTools;
using HXINTL_HFT_2022232.Data;
using HXINTL_HFT_2022232.Logic;
using HXINTL_HFT_2022232.Models;
using HXINTL_HFT_2022232.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXINTL_HFT_2022232.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MusicLibraryContext mlc = new MusicLibraryContext();
            AlbumRepository albumRepo = new AlbumRepository(mlc);
            TrackRepository trackRepo = new TrackRepository(mlc);
            ArtistRepository artistRepo = new ArtistRepository(mlc);
            TrackLogic trackLogic = new TrackLogic(trackRepo);
            AlbumLogic albumLogic = new AlbumLogic(albumRepo);
            ArtistLogic artistLogic = new ArtistLogic(artistRepo);

        }
    }
}

