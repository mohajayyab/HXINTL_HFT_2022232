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
        void Create(Beand albumEvent);
        void Delete(int Albumid);
        IQueryable<Beand> GetAll();
        Beand Read(int Albumid);
        void Update(Beand AlbumEvent);
    }
}
