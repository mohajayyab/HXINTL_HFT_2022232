using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXINTL_HFT_2022232.Models;
using HXINTL_HFT_2022232.Data;

namespace HXINTL_HFT_2022232.Repository
{
     class TrackRepository : ITrackRepository
    {
        MusicLibraryContext db;
        public TrackRepository(MusicLibraryContext db)
        {
            this.db = db;
        }
        public void Create(Track track)
        {
            db.Tracks.Add(track);
            db.SaveChanges();
        }
        public Track Read(int Trackid)
        {
            return
                db.Tracks.FirstOrDefault(t => t.TrackId == Trackid);
        }
        public IQueryable<Track> GetAll()
        {
            return db.Tracks;
        }
        public void Delete(int Trackid)
        {
            var TrackToDelete = Read(Trackid);
            db.Tracks.Remove(TrackToDelete);
            db.SaveChanges();
        }
        public void Update(Track track)
        {
            var TrackToUpdate = Read(track.TrackId);
            TrackToUpdate.NamePlace = track.NamePlace;
            db.SaveChanges();
        }
    }
}
