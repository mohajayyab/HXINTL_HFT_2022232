using HXINTL_HFT_2022232.Models;
using HXINTL_HFT_2022232.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HXINTL_HFT_2022232.Logic
{
    public class TrackLogic : ITrackLogic
    {
        private ITrackRepository _trackRepository;
        public TrackLogic(ITrackRepository trackRepository)
        {
            this._trackRepository = trackRepository;
        }

        public void CreatTrack(int trackId, string namePlace, int length)
        {
            Track track = new Track
            {
                TrackId = trackId,
                NamePlace = namePlace,
                Length = length

            };
            this._trackRepository.Create(track);
        }

        public void DeleteTrack(int trackId)
        {
            Track track = _trackRepository.Read(trackId);
            if (track == null)
            {
                throw new Exception("NOt valid Track Id ");
            }
            this._trackRepository.Delete(trackId);
        }


        public Track GetTrack(int TrackId)
        {
            Track track = _trackRepository.Read(TrackId);
            if (track== null)
            {
                throw new Exception("Not Valid Artist Id ");
            }
            else
                return track;
        }

        public List<Track> GetTracks()
        {
            return this._trackRepository.GetAll().ToList();
        }

        public void UpdateTrack(Track track)
        {
            Track currentTrack = _trackRepository.Read(track.TrackId);
            if (currentTrack == null)
            {
                throw new Exception("Not Existing ");
            }
            currentTrack.AlbumId = track.AlbumId;
            currentTrack.Length = track.Length;
            currentTrack.NamePlace = track.NamePlace;
            this._trackRepository.Update(currentTrack);
        }
        public Track GetLongestTrack()
        {
            return this._trackRepository.GetAll().ToList().OrderByDescending(x => x.Length).First();

        }
        public Track GetShortestTrack()
        {
            return this._trackRepository.GetAll().ToList().OrderBy(x => x.Length).First();
        }
    }
}
