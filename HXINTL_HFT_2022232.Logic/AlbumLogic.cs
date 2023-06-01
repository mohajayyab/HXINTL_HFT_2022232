using HXINTL_HFT_2022232.Models;
using HXINTL_HFT_2022232.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXINTL_HFT_2022232.Logic
{
    public class AlbumLogic : IAlbumLogic
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumLogic(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;

        }

        public void CreateAlbum(int albumID, string title)
        {
            Album album = new Album
            { AlbumID = albumID, Title = title };
            _albumRepository.Create(album);

        }

        public void DeleteAlbum(int albumID)
        {
            Album album = _albumRepository.Read(albumID);

            if (album == null)
            {
                throw new Exception("Not valid album id");
            }

            _albumRepository.Delete(albumID);
        }

        public Album GetAlbum(int albumID)
        {
            Album album = _albumRepository.Read(albumID);
            if (album == null)
            {
                throw new Exception("not valid albumId");
            }
            else
                return album;

        }

        public List<Album> GetAlbums()
        {
            return _albumRepository.GetAll()
                    .ToList();
        }

        public void UpdateAlbum(Album album)
        {
            Album currentAlbum = _albumRepository.Read(album.AlbumID);
            if (currentAlbum == null)
            {
                throw new Exception("Not Existing");
            }
            currentAlbum.Title = album.Title;

            _albumRepository.Update(currentAlbum);
        }
        public List<Album> GetAlbumRepositoryOrderedByTitle()
        {
            return _albumRepository.GetAll()
                .OrderBy(album => album.Title)
                .ToList();
        }

        public double AVGPrice()
        {
            return _albumRepository.GetAll()
                .Average(t => t.BasePrice);
        }

        public IEnumerable<KeyValuePair<string, double>> AVGPriceByAlbums()
        {
            return from x in _albumRepository.GetAll()
                   group x by x.Track.NamePlace into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.BasePrice));
        }
    }
}
