using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXINTL_HFT_2022232.Models;

namespace HXINTL_HFT_2022232.Repository
{
    public interface IAlbumRepository
    {
        void Create(Album albumEvent);
        void Delete(int Albumid);
        IQueryable<Album> GetAll();
        Album Read(int Albumid);
        void Update(Album AlbumEvent);
    }
}
