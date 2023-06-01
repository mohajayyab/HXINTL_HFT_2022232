using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXINTL_HFT_2022232.Models;

namespace HXINTL_HFT_2022232.Logic
{
    public interface ITrackLogic
    {
        List<Track> GetTracks();
        Track GetTrack(int TrackId);
        void CreatTrack(int TrackId, string NamePlace, int Length);
        void UpdateTrack(Track track);
        void DeleteTrack(int TrackId);
    }
}
