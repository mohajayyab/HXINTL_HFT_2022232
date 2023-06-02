using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXINTL_HFT_2022232.Models;

namespace HXINTL_HFT_2022232.Logic
{
    public interface IMotorcycleLogic
    {
        //CRUD
        void Create(Motorcycle obj);
        Motorcycle Read(int id);
        IQueryable<Motorcycle> ReadAll();
        void Update(Motorcycle obj);
        void Delete(int id);
    }
}
