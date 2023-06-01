using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXINTL_HFT_2022232.Models;
using HXINTL_HFT_2022232.Data;

namespace HXINTL_HFT_2022232.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        protected readonly MusicLibraryContext db;
        public AlbumRepository(MusicLibraryContext db)
        {
            this.db = db;
        }
        public void Create(Beand album)
        {
            db.Albums.Add(album);
            db.SaveChanges();
        }
        public Beand Read(int Albumid)
        {
            return
                db.Albums.FirstOrDefault(t => t.AlbumID == Albumid);
        }
        public IQueryable<Beand> GetAll()
        {
            return db.Albums;
        }
        public void Delete(int Albumid)
        {
            var AlbumToDelete = Read(Albumid);
            db.Albums.Remove(AlbumToDelete);
            db.SaveChanges();
        }
        public void Update(Beand album)
        {
            var AlbumToUpdate = Read(album.AlbumID);
            AlbumToUpdate.Title = album.Title;
            AlbumToUpdate.BasePrice = album.BasePrice;
            db.SaveChanges();
        }
    }
}
