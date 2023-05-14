using HXINTL_HFT_2022232.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HXINTL_HFT_2022232.Data
{
    public class MusicLibraryContext : DbContext
    {

        // Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename="|DataDirectory|\HXINTLDatabase.mdf"; Integrated Security=True; MultipleActiveResultSets=True

        public MusicLibraryContext()
        {

            this.Database.EnsureCreated();
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }

        public virtual DbSet<Artist> Artists { get; set; }

        public MusicLibraryContext(DbContextOptions<MusicLibraryContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=| DataDirectory |\GQFJHHDbContext.mdf;Integrated Security=True;MultipleActiveResults=True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Album
            Album a1 = new Album() { AlbumID = 11, Title = "Title 1", BasePrice = 10 };
            Album a2 = new Album() { AlbumID = 22, Title = "Title 2", BasePrice = 11 };
            Album a3 = new Album() { AlbumID = 33, Title = "Title 3", BasePrice = 12 };
            Album a4 = new Album() { AlbumID = 44, Title = "Title 4  ", BasePrice = 13, TracktID = 1 };
            Album a5 = new Album() { AlbumID = 55, Title = "Title 5  ", BasePrice = 14, TracktID = 1 };
            Album a6 = new Album() { AlbumID = 66, Title = "Title 6 ", BasePrice = 15, TracktID = 1 };
            Album a7 = new Album() { AlbumID = 77, Title = "Title 7 ", BasePrice = 16, TracktID = 1 };
            Album a8 = new Album() { AlbumID = 88, Title = "Title 8 ", BasePrice = 17, TracktID = 1 };
            Album a9 = new Album() { AlbumID = 99, Title = "Title 9 ", BasePrice = 18, TracktID = 1 };
            Album a10 = new Album() { AlbumID = 100, Title = "Title 10 ", BasePrice = 19, TracktID = 1 };
            //Track
            Track t1 = new Track() { TrackId = 1, NamePlace = "ballads", Length = 10 };
            Track t2 = new Track() { TrackId = 2, NamePlace = "novelty songs", Length = 15 };
            Track t3 = new Track() { TrackId = 3, NamePlace = "anthems", Length = 20 };
            Track t4 = new Track() { TrackId = 4, NamePlace = "rock", Length = 30 };
            Track t5 = new Track() { TrackId = 5, NamePlace = "blues", Length = 40 };
            Track t6 = new Track() { TrackId = 6, NamePlace = "life", Length = 50 };
            Track t7 = new Track() { TrackId = 7, NamePlace = "soul songs", Length = 60 };
            Track t8 = new Track() { TrackId = 8, NamePlace = "Pop ", Length = 70 };
            Track t9 = new Track() { TrackId = 9, NamePlace = " Classical", Length = 80 };
            Track t10 = new Track() { TrackId = 10, NamePlace = "Hip-Hop and Rap", Length = 75 };
            Track t11 = new Track() { TrackId = 11, NamePlace = "EDM (Electronic Dance Music)", Length = 60 };
            Track t12 = new Track() { TrackId = 12, NamePlace = "Metal", Length = 55 };
            //Artist
            Artist ar1 = new Artist() { ArtistId = 1118, Name = "David", Age = 4, Albumid = 11 };
            Artist ar2 = new Artist() { ArtistId = 222, Name = "James ", Age = 33, Albumid = 11 };
            Artist ar3 = new Artist() { ArtistId = 333, Name = "Demi  ", Age = 23, Albumid = 22 };
            Artist ar4 = new Artist() { ArtistId = 444, Name = "Diana  ", Age = 40, Albumid = 22 };
            Artist ar5 = new Artist() { ArtistId = 555, Name = "Eminem ", Age = 25, Albumid = 33 };
            Artist ar6 = new Artist() { ArtistId = 666, Name = "Eve ", Age = 40, Albumid = 33 };
            Artist ar7 = new Artist() { ArtistId = 777, Name = "Johnny  ", Age = 27, Albumid = 44 };
            Artist ar8 = new Artist() { ArtistId = 888, Name = "Mate ", Age = 17, Albumid = 44 };
            Artist ar9 = new Artist() { ArtistId = 999, Name = " Bill ", Age = 57, Albumid = 55 };
            Artist ar10 = new Artist() { ArtistId = 1000, Name = "Foxy ", Age = 60, Albumid = 55 };
            Artist ar11 = new Artist() { ArtistId = 111, Name = "Rex ", Age = 33, Albumid = 66 };

          
            modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasOne(artist => artist.Album)
                    .WithMany(album => album.Artists)
                    .HasForeignKey(album => album.Albumid)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasOne(album => album.Track)
                    .WithMany(track => track.Albums)
                    .HasForeignKey(track => track.TracktID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

           

            modelBuilder.Entity<Track>().HasData(t4, t5, t6);
            modelBuilder.Entity<Album>().HasData(a1, a2, a3);
            modelBuilder.Entity<Artist>().HasData(ar1, ar2, ar3);
        }


    }
}
