﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXINTL_HFT_2022232.Data;
using HXINTL_HFT_2022232.Models;

namespace HXINTL_HFT_2022232.Repository
{
     public class ArtistRepository : IArtistRepository
    {
        protected readonly MusicLibraryContext db;
        public ArtistRepository(MusicLibraryContext db)
        {
            this.db = db;
        }
        public void Create(Artist artist)
        {
            db.Artists.Add(artist);
            db.SaveChanges();
        }
        public Artist Read(int Artistid)
        {
            return
                db.Artists.FirstOrDefault(t => t.ArtistId == Artistid);
        }
        public IQueryable<Artist> GetAll()
        {
            return db.Artists;
        }
        public void Delete(int Artistid)
        {
            var ArtistToDelete = Read(Artistid);
            db.Artists.Remove(ArtistToDelete);
            db.SaveChanges();
        }
        public void Update(Artist artist)
        {
            var ArtistToUpdate = Read(artist.ArtistId);
            ArtistToUpdate.Name = artist.Name;
            db.SaveChanges();
        }
    }
}
