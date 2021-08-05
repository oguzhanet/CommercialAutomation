using CommercialAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Business.Abstract
{
    public interface ICargoFollowService
    {
        List<CargoFollow> GetAll();
        CargoFollow GetById(int id);
        void Add(CargoFollow cargoFollow);
        void Update(CargoFollow cargoFollow);
        void Delete(CargoFollow cargoFollow);
    }
}
