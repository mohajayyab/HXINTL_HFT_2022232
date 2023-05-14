using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXINTL_HFT_2022232.Models;
using HXINTL_HFT_2022232.Data;

namespace HXINTL_HFT_2022232.Repository
{
    class AlbumRepository : IAlbumRepository
    {
        protected readonly MusicLibraryContext db;
        public AlbumRepository(MusicLibraryContext db)
        {
            this.db = db;
        }
        public void Create(Album album)
        {
            db.Albums.Add(album);
            db.SaveChanges();
        }
        public Album Read(int Albumid)
        {
            return
                db.Albums.FirstOrDefault(t => t.AlbumID == Albumid);
        }
        public IQueryable<Album> GetAll()
        {
            return db.Albums;
        }
        public void Delete(int Albumid)
        {
            var AlbumToDelete = Read(Albumid);
            db.Albums.Remove(AlbumToDelete);
            db.SaveChanges();
        }
        public void Update(Album album)
        {
            var AlbumToUpdate = Read(album.AlbumID);
            AlbumToUpdate.Title = album.Title;
            AlbumToUpdate.BasePrice = album.BasePrice;
            db.SaveChanges();
        }
    }
}
