using CommercialAutomation.Business.Abstract;
using CommercialAutomation.DataAccess.Abstract;
using CommercialAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Business.Concrete
{
    public class CargoFollowManager : ICargoFollowService
    {
        private ICargoFollowDal _cargoFollowDal;

        public CargoFollowManager(ICargoFollowDal cargoFollowDal)
        {
            _cargoFollowDal = cargoFollowDal;
        }

        public void Add(CargoFollow cargoFollow)
        {
            _cargoFollowDal.Add(cargoFollow);
        }

        public void Delete(CargoFollow cargoFollow)
        {
            _cargoFollowDal.Delete(cargoFollow);
        }

        public List<CargoFollow> GetAll()
        {
            return _cargoFollowDal.GetAll();
        }

        public CargoFollow GetById(int id)
        {
            return _cargoFollowDal.Get(x => x.CargoFollowId == id);
        }

        public void Update(CargoFollow cargoFollow)
        {
            _cargoFollowDal.Update(cargoFollow);
        }
    }
}
