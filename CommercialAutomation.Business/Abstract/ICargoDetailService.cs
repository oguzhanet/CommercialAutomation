using CommercialAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Business.Abstract
{
    public interface ICargoDetailService
    {
        List<CargoDetail> GetAll();
        CargoDetail GetById(int id);
        void Add(CargoDetail cargoDetail);
        void Update(CargoDetail cargoDetail);
        void Delete(CargoDetail cargoDetail);
    }
}
