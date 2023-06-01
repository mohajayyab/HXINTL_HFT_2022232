using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXINTL_HFT_2022232.Models;

namespace HXINTL_HFT_2022232.Repository
{
    public interface ITrackRepository
    {
        void Create(Track TrackEvent);
        void Delete(int Trackid);
        IQueryable<Track> GetAll();
        Track Read(int Trackid);
        void Update(Track TrackEvent);
    }
}
